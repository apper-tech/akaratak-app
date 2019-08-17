using System.Collections.Generic;
using System.Threading.Tasks;
using akaratak_app.Helpers;
using akaratak_app.Models;


namespace akaratak_app.Data
{
    public interface IPropertyRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<Property>> GetProperties(PropertyToListDto propParams);
        Task<Property> GetProperty(int id);
        Task<ICollection<Category>> GetCategories();
        Task<ICollection<Tags>> GetTags();
        Task<ICollection<Currency>> GetCurrencies();
        Task<ICollection<Country>> GetCountries();
        Task<ICollection<City>> GetCities(string code);
        Task<ICollection<Photo>> GetPhotos(int propertyId);
        Task<Photo> GetMainPhotoForProperty(int propertyId);
        Property CastPropertyFromInsert(PropertyToInsertDto PropertyDto);

    }
}