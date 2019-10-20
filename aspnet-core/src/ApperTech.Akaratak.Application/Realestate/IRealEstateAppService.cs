using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Realestate.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApperTech.Akaratak.Realestate
{
    public interface IPropertyAppService : IApplicationService
    {
        Task<int> Create(CreatePropertyInput input);
        Task<PropertyDto> GetById(int propertyId);
        Task<List<PropertyDto>> GetByUser();
        Task<List<PropertyDto>> Filter(FilterPropertyInput input);
        Task<bool> AddPhotoForProperty(int propertyId, IFormFile file);
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
        Task<TagDto> Create(CreateTagInput input);

    }
}
