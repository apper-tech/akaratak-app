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
        Task<PagedList<Property>> GetProperties(PropertyParams propParams);
        Task<Property> GetProperty(int id);
        Task<ICollection<SubCategory>> GetCategories();
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForProperty(int propertyId);
    }
}