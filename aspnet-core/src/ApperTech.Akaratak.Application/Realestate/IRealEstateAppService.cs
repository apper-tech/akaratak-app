using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using ApperTech.Akaratak.Realestate.Dto;
using Microsoft.AspNetCore.Http;

namespace ApperTech.Akaratak.Realestate
{
    public interface IPropertyAppService : IApplicationService
    {
        Task<int> Create(CreatePropertyInput input);
        Task<PropertyDto> GetById(int propertyId);
        Task<List<PropertyDto>> GetAll(GetAllPropertyInput input);
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

    public interface IPhotoAppService : IApplicationService
    {
        Task<List<PhotoDto>> GetPhotos(int propertyId);

        Task<bool> AddPhotoForProperty(int propertyId, IFormFile file);
    }
}
