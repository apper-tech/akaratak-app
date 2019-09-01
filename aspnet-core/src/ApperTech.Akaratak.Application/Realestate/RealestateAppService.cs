using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using ApperTech.Akaratak.Realestate.Dto;

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
                (await _repository.GetAllListAsync());
        }
    }
}
