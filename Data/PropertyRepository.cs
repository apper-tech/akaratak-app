using System.Threading.Tasks;
using akaratak_app.Helpers;
using akaratak_app.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace akaratak_app.Data
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _context;

        public PropertyRepository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<ICollection<SubCategory>> GetCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<Photo> GetMainPhotoForProperty(int propertyId)
        {
            return await _context.Photos.Where(x => x.Property.Property_ID == propertyId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Photo_ID == id);
            return photo;
        }

        public async Task<PagedList<Property>> GetProperties(PropertyParams propParams)
        {
            var properties = _context.Properties.Include(p => p.Photos).OrderByDescending(p => p.PublishDate).AsQueryable();

            /* Property Search Features Logic */

            properties = properties.Where(p => p.Features.Area >= propParams.Area);

            if (propParams.Cladding)
            {
                properties = properties = properties.Where(p => p.Features.Cladding);
            }

            if (propParams.BathroomNumber > 0)
            {
                properties = properties = properties.Where(p => p.Features.Bathrooms >= propParams.BathroomNumber);
            }

            if (!string.IsNullOrEmpty(propParams.OrderBy))
            {
                switch (propParams.OrderBy)
                {
                    case "sale_price":
                        properties = properties.OrderByDescending(p => p.Offer.Sale);
                        break;
                    default:
                        properties = properties.OrderByDescending(p => p.Offer.Sale);
                        break;
                }
            }

            return await PagedList<Property>.CreateAsync(properties, propParams.PageNumber, propParams.PageSize);

        }

        public async Task<Property> GetProperty(int id)
        {
            var property = await _context.Properties.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Property_ID == id);
            return property;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}