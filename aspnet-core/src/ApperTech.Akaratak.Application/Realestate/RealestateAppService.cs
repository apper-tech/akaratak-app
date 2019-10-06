using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Timing;
using Abp.UI;
using ApperTech.Akaratak.Realestate.Dto;
using ApperTech.Akaratak.Realestate.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApperTech.Akaratak.Realestate
{
    public class PropertyAppService : ApplicationService, IPropertyAppService
    {
        private readonly IRepository<Property> _repository;
        private readonly ITagManager _tagManager;
        private readonly IPhotoManager _photoManager;
        private readonly IObjectMapper _objectMapper;

        public PropertyAppService(IRepository<Property> repository,
            ITagManager tagManager,
            IPhotoManager photoManager,
            IObjectMapper objectMapper)
        {
            _repository = repository;
            _tagManager = tagManager;
            _photoManager = photoManager;
            _objectMapper = objectMapper;
        }
        [AbpAuthorize()]
        public async Task<int> Create(CreatePropertyInput input)
        {
            var property = new Property
            {
                Address = _objectMapper.Map<Address>(input.Address),
                Offer = _objectMapper.Map<Offer>(input.Offer),
                Features = _objectMapper.Map<Features>(input.Features),
                PropertyTypeId = input.PropertyType,
                ListingDate = Clock.Now,
                PublishDate = Clock.Now,
                ExpireDate = input.ExpireDate,
            };
            (await _tagManager.GetByIds(input.Features.Tags))
                .ToList().ForEach(x => property.Features.FeaturesTags
                    .Add(new FeaturesTag { Tag = x, Features = property.Features }));

            var id = await _repository.InsertAndGetIdAsync(property);

            if (id > 0)
                return id;
            else
                throw new UserFriendlyException("Error While Inserting Property");
        }

        public async Task<PropertyDto> GetById(int propertyId)
        {
            return _objectMapper.Map<PropertyDto>(await GetPropertyWithDependencies(propertyId));
        }

        public async Task<List<PropertyDto>> GetAll(GetAllPropertyInput input)
        {
            return _objectMapper.Map<List<PropertyDto>>(
                (await _repository.GetAllListAsync())
                .Select(async x => (await GetPropertyWithDependencies(x.Id)))
                .Select(t => t.Result)
                .WhereIf(input.Bedrooms.HasValue,
                    p => p.Features.Bedrooms > input.Bedrooms)
                .ToList()
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));
        }

        [AbpAuthorize()]
        public async Task<bool> AddPhotoForProperty(int propertyId, [FromForm]IFormFile file)
        {
            return !(await _repository.UpdateAsync(
                    (await GetPropertyWithDependencies(propertyId))
                    .AddPhotos(new List<Photo>
                    {
                        (await this._photoManager.UploadPhoto(file))
                    }))
                ).IsNullOrDeleted();
        }

        private async Task<Property> GetPropertyWithDependencies(int propertyId)
        {
            if (propertyId <= 0)
                throw new UserFriendlyException("Property Id Invalid");

            var property = (await _repository
                .GetAllIncluding(
                    x => x.Address.City.Country,
                    x => x.PropertyType,
                    x => x.Features,
                    x => x.Offer.Currency
                )
                .Include(x => x.Photos)
                .Include(x => x.Features.FeaturesTags)
                .ThenInclude(x => x.Tag)
                .Where(x => x.Id == propertyId)
                .FirstOrDefaultAsync());

            if (property != null)
                return property;
            else
                throw new UserFriendlyException("Property Doesn't Exist!");
        }
    }

    public class CurrencyAppService : ApplicationService, ICurrencyAppService
    {
        private readonly IRepository<Currency> _repository;
        private readonly IObjectMapper _objectMapper;

        public CurrencyAppService(IRepository<Currency> repository
            , IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<CurrencyDto>> GetAll()
        {
            return _objectMapper.Map<List<CurrencyDto>>
                (await _repository.GetAllListAsync());
        }
    }

    public class CountryAppService : ApplicationService, ICountryAppService
    {
        private readonly IRepository<Country> _repository;
        private readonly IObjectMapper _objectMapper;

        public CountryAppService(IRepository<Country> repository
            , IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<CountryDto>> GetAll()
        {
            return _objectMapper.Map<List<CountryDto>>
                (await _repository.GetAllListAsync());
        }
    }

    public class CityAppService : ApplicationService, ICityAppService
    {
        private readonly IRepository<City> _repository;
        private readonly IObjectMapper _objectMapper;

        public CityAppService(IRepository<City> repository
            , IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<CityDto>> GetAll()
        {
            return _objectMapper.Map<List<CityDto>>
            (await _repository
                .GetAllIncluding(city => city.Country)
                .ToListAsync()
            );
        }

        public async Task<List<CityDto>> GetByCountry(int countryId)
        {
            return _objectMapper.Map<List<CityDto>>
            (await _repository
                .GetAllIncluding(city => city.Country)
                .Where(city => city.Country.Id == countryId)
                .ToListAsync()
            );
        }
    }

    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category> _repository;
        private readonly IObjectMapper _objectMapper;

        public CategoryAppService(IRepository<Category> repository
            , IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return _objectMapper.Map<List<CategoryDto>>
            (await _repository
                .GetAllIncluding(type => type.PropertyTypes)
                .ToListAsync());
        }
    }

    public class TagAppService : ApplicationService, ITagAppService
    {
        private readonly IRepository<Tag> _repository;
        private readonly IObjectMapper _objectMapper;

        public TagAppService(IRepository<Tag> repository
            , IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<TagDto>> GetAll()
        {
            return _objectMapper.Map<List<TagDto>>
            (await _repository
                .GetAllListAsync());
        }
        [AbpAuthorize()]
        public async Task<TagDto> Create(CreateTagInput input)
        {
            if ((await _repository.GetAllListAsync())
                .Where(x => x.Name == input.Name)
                .ToList().Count == 0)
                return _objectMapper.Map<TagDto>(
                   await _repository.GetAsync(
                       await _repository.InsertAndGetIdAsync(new Tag
                       {
                           Name = input.Name
                       })));
            throw new UserFriendlyException("Tag Already Exists!");
        }
    }
}


