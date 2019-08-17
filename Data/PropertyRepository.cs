using System;
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

        public async Task<ICollection<Category>> GetCategories()
        {
            return await _context.Category.Include(c => c.SubCategory).ToListAsync();
        }
        public async Task<ICollection<Currency>> GetCurrencies()
        {
            return await _context.Currency.ToListAsync();
        }

        public async Task<Photo> GetMainPhotoForProperty(int propertyId)
        {
            return await _context.Photo.Where(x => x.Property.ID == propertyId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<ICollection<Photo>> GetPhotos(int propertyId)
        {
            var property = await _context.Property.Include(p => p.Photos).Where(p => p.ID == propertyId).FirstOrDefaultAsync();
            return property.Photos.ToList();
        }
        private IQueryable<Property> GetPropertiesWithDependencies()
        {
            return _context.Property
            .Include(p => p.Offer).ThenInclude(o => o.Currency)
            .Include(p => p.SubCategory).ThenInclude(o => o.Category)
            .Include(p => p.Address).ThenInclude(a => a.City).ThenInclude(c => c.Country)
            .Include(p => p.Photos)
            .Include(f => f.Features).ThenInclude(o => o.Directon)
            .Include(f => f.Features).ThenInclude(o => o.Tags)
            .OrderByDescending(p => p.PublishDate).AsQueryable();
        }
        public async Task<PagedList<Property>> GetProperties(PropertyToListDto propParams)
        {
            var properties = this.GetPropertiesWithDependencies();

            /* Date */
            if (propParams.PublishDate != null)
                properties = properties.Where(p => p.PublishDate >= propParams.PublishDate);

            /* Area */
            if (propParams.Area > 0)
                properties = properties.Where(p => p.Features.Area >= propParams.Area);

            /* Bathrooms Number */
            if (propParams.Bathrooms > 0)
                properties = properties.Where(p => p.Features.Bathrooms >= propParams.Bathrooms);
            /* Owners */
            if (propParams.Owners > 0)
                properties = properties.Where(p => p.Features.Owners >= propParams.Owners);

            /* Rooms */
            if (propParams.Rooms > 0)
                properties = properties.Where(p => p.Features.Rooms >= propParams.Rooms);

            /* Balconies */
            if (propParams.Balconies > 0)
                properties = properties.Where(p => p.Features.Balconies >= propParams.Balconies);

            /* PropertyAge */
            if (propParams.PropertyAge > 0)
                properties = properties.Where(p => p.Features.PropertyAge >= propParams.PropertyAge);

            /* Country and City Filters */
            if (propParams.Country_ID > 0)
            {
                properties = properties.Where(p => p.Address.City.Country.ID == propParams.Country_ID);
                if (propParams.City_ID > 0)
                    properties = properties.Where(p => p.Address.City.ID == propParams.City_ID);
            }
            /* Cladding */
            properties = propParams.Cladding ? properties.Where(p => p.Features.Cladding) : properties;

            /* Property Direction */
            properties = propParams.Direction_East ? properties.Where(p => p.Features.Directon.East) : properties;
            properties = propParams.Direction_North ? properties.Where(p => p.Features.Directon.North) : properties;
            properties = propParams.Direction_South ? properties.Where(p => p.Features.Directon.South) : properties;
            properties = propParams.Direction_West ? properties.Where(p => p.Features.Directon.West) : properties;

            /* Empty */
            properties = propParams.Empty ? properties.Where(p => p.Features.Empty) : properties;

            /* Heating */
            properties = propParams.Heating ? properties.Where(p => p.Features.Heating) : properties;

            /* GasLine */
            properties = propParams.GasLine ? properties.Where(p => p.Features.GasLine) : properties;

            /* Internet */
            properties = propParams.Internet ? properties.Where(p => p.Features.Internet) : properties;

            /* Elevator */
            properties = propParams.Elevator ? properties.Where(p => p.Features.Elevator) : properties;

            /* Parking */
            properties = propParams.Parking ? properties.Where(p => p.Features.Parking) : properties;

            /* Tags */
            if (propParams.Tags.Count > 0)
                foreach (var tag in propParams.Tags)
                    properties = properties.Where(p => p.Features.Tags.Any(t => t.Name == tag));


            if (!string.IsNullOrEmpty(propParams.OfferType))
            {
                switch (propParams.OfferType.ToLower())
                {
                    case "sale":
                        properties = properties.Where(p => p.Offer.Sale > 0);
                        break;
                    case "rent":
                        properties = properties.Where(p => p.Offer.Rent > 0);
                        break;
                    case "invest":
                        properties = properties.Where(p => p.Offer.Invest > 0);
                        break;
                    case "swap":
                        properties = properties.Where(p => p.Offer.Swap);
                        break;
                }
            }

            /* OrderBy */
            if (!string.IsNullOrEmpty(propParams.OrderBy))
            {
                switch (propParams.OrderBy.ToLower())
                {
                    case "sale_price":
                        properties = properties.OrderByDescending(p => p.Offer.Sale);
                        break;
                    case "property_age":
                        properties = properties.OrderByDescending(p => p.Features.PropertyAge);
                        break;
                    default:
                        properties = properties.OrderByDescending(p => p.PublishDate);
                        break;
                }
            }

            return await PagedList<Property>.CreateAsync(properties, propParams.PageNumber, propParams.PageSize);

        }

        public async Task<Property> GetProperty(int id)
        {
            var property = await this.GetPropertiesWithDependencies().FirstOrDefaultAsync(p => p.ID == id);
            return property;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<Tags>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<ICollection<Country>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<ICollection<City>> GetCities(string code)
        {
            var country = await _context.Country.Where(c => c.Code == code).FirstOrDefaultAsync();

            return await _context.City
            .Where(c => c.Country.ID == country.ID).ToListAsync();
        }

        public Property CastPropertyFromInsert(PropertyToInsertDto PropertyDto)
        {
            var tags = new List<Tags>();
            foreach (var tagID in PropertyDto.Tags)
                tags.Add(_context.Tags.Where(t => t.ID == tagID).FirstOrDefault());
            var city = _context.City.Where(c => c.ID == PropertyDto.City).FirstOrDefault();
            var sub = _context.SubCategory.Where(c => c.ID == PropertyDto.Type).FirstOrDefault();
            var curr = _context.Currency.Where(c => c.ID == PropertyDto.Offer.Currency).FirstOrDefault();

            var property = new Property
            {
                Address = new Address
                {
                    City = city,
                    Location = PropertyDto.Location,
                    ZipCode = PropertyDto.ZipCode,
                    Street = PropertyDto.Street,
                    Latitude = PropertyDto.Latitude,
                    Longitude = PropertyDto.Longitude
                },
                Offer = new Offer
                {
                    Sale = PropertyDto.Offer.Sale,
                    Rent = PropertyDto.Offer.Rent,
                    Invest = PropertyDto.Offer.Invest,
                    Swap = PropertyDto.Offer.Swap,
                    Currency = curr
                },
                Features = new Features
                {
                    Directon = new Directon
                    {
                        West = PropertyDto.DirectionWest,
                        East = PropertyDto.DirectionEast,
                        North = PropertyDto.DirectionNorth,
                        South = PropertyDto.DirectionSouth
                    },
                    Cladding = PropertyDto.Cladding,
                    Empty = PropertyDto.Empty,
                    Heating = PropertyDto.Heating,
                    GasLine = PropertyDto.GasLine,
                    Internet = PropertyDto.Internet,
                    Elevator = PropertyDto.Elevator,
                    Parking = PropertyDto.Parking,
                    Area = PropertyDto.Area,
                    Owners = PropertyDto.Owners,
                    Rooms = PropertyDto.Rooms,
                    Bedrooms = PropertyDto.Bedrooms,
                    Bathrooms = PropertyDto.Bathrooms,
                    Balconies = PropertyDto.Balconies,
                    PropertyAge = PropertyDto.PropertyAge,
                    Title = PropertyDto.Title,
                    Description = PropertyDto.Description,
                    Tags = tags
                },
                Listing = new Listing
                {
                    //add identintiy
                    UserID = new System.Guid()
                },
                SubCategory = sub,
                ListingDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(3),
                PublishDate = DateTime.Now
            };
            return property;
        }
    }
}