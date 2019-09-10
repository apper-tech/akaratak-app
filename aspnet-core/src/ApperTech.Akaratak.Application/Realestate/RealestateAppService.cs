using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Timing;
using Abp.UI;
using ApperTech.Akaratak.Realestate.Dto;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApperTech.Akaratak.Realestate
{
    public class PropertyAppService : ApplicationService, IPropertyAppService
    {
        private readonly IRepository<Property> _repository;
        private readonly IObjectMapper _objectMapper;

        public PropertyAppService(IRepository<Property> repository,
            IObjectMapper objectMapper)
        {
            _repository = repository;
            _objectMapper = objectMapper;
        }
        public async Task<PropertyDto> Create(CreatePropertyInput input)
        {
            return _objectMapper.Map<PropertyDto>(
                await _repository.InsertAsync(new Property
                {
                    Address = _objectMapper.Map<Address>(input.Address),
                    Offer = _objectMapper.Map<Offer>(input.Offer),
                    Features = _objectMapper.Map<Features>(input.Features),
                    PropertyType = new PropertyType { Id = input.PropertyType },
                    ListingDate = Clock.Now,
                    PublishDate = Clock.Now,
                    ExpireDate = input.ExpireDate,
                }));
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
    }

    public class PhotoAppService : ApplicationService, IPhotoAppService
    {
        private readonly IRepository<Property> _repository;
        private readonly IObjectMapper _objectMapper;
        private readonly ISettingManager _settingManager;
        private Cloudinary _cloudinary;

        public PhotoAppService(IRepository<Property> repository
            , IObjectMapper objectMapper
            , ISettingManager settingManager)
        {
            _repository = repository;
            _objectMapper = objectMapper;
            _settingManager = settingManager;

            InitCloudinary();
        }

        private async void InitCloudinary()
        {
            _cloudinary = new Cloudinary(
                new Account(
                    await _settingManager.GetSettingValueAsync("CloudinaryCloudName"),
                    await _settingManager.GetSettingValueAsync("CloudinaryApiKey"),
                    await _settingManager.GetSettingValueAsync("CloudinaryApiSecret")
                )
            );
        }

        public async Task<List<PhotoDto>> GetPhotos(int propertyId)
        {
            return _objectMapper.Map<List<PhotoDto>>
            (await _repository
                .GetAllListAsync());
        }

        public async Task<List<PhotoDto>> AddPhotoForProperty(int propertyId, [FromForm]IFormFile file)
        {
            var property = await _repository
                .GetAllIncluding(p => p.Photos)
                .Where(p => p.Id == propertyId)
                .FirstAsync();

            if (property == null)
                throw new UserFriendlyException("Property Doesn't Exist");
            var photoDto = new PhotoDto();

            ImageUploadResult uploadResult;

            if (file.Length <= 0)
                return ObjectMapper.Map<List<PhotoDto>>((await _repository.UpdateAsync(property)).Photos);
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation().Width(1200).Height(1000).Crop("fill")
                };
                uploadResult = _cloudinary.Upload(uploadParams);
            }


            photoDto.Url = uploadResult.Uri.ToString();
            photoDto.PublicId = uploadResult.PublicId;


            if (!property.Photos.Any(m => m.IsMain))
                photoDto.IsMain = true;

            property.Photos.Add(ObjectMapper.Map<Photo>(photoDto));

            return ObjectMapper.Map<List<PhotoDto>>((await _repository.UpdateAsync(property)).Photos);
        }
    }
}


