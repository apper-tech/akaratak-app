using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Realestate.Dto;

namespace ApperTech.Akaratak.Realestate
{
    public interface IPropertyAppService : IAsyncCrudAppService<PropertyDto,
        int,
        GetAllPropertyInput,
        CreatePropertyInput,
        UpdatePropertyInput>
    {

    }

    public interface ICurrencyAppService : IApplicationService
    {
        Task<List<CurrencyDto>> GetAll();
    }
    public interface ICountryAppService : IApplicationService
    {
        Task<List<CountryDto>> GetAll();
    }
    public interface ICityAppService : IApplicationService
    {
        Task<List<CityDto>> GetAll();
        Task<List<CityDto>> GetByCountry(int countryId);

    }

    public interface ICategoryAppService : IApplicationService
    {
        Task<List<CategoryDto>> GetAll();
    }

    public interface ITagAppService : IApplicationService
    {
        Task<List<TagDto>> GetAll();
    }
}
