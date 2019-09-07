using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using ApperTech.Akaratak.Realestate.Dto;
using Microsoft.EntityFrameworkCore;

namespace ApperTech.Akaratak.Realestate
{
    public class PropertyAppService :
        AsyncCrudAppService<Property, PropertyDto, int, GetAllPropertyInput, CreatePropertyInput, UpdatePropertyInput>,
        IPropertyAppService
    {
        public PropertyAppService(IRepository<Property, int> repository) : base(repository)
        {
        }

        public override Task<PropertyDto> Create(CreatePropertyInput input)
        {
            return base.Create(input);
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

}
