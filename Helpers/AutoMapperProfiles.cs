using System.Linq;
using AutoMapper;
using akaratak_app.Dtos;
using akaratak_app.Models;

namespace akaratak_app.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Property, PropertyToReturnDto>();
            CreateMap<Address, AddressToReturnDto>();
            CreateMap<Country, CountryToReturnDto>();
            CreateMap<City, CityToReturnDto>();
            CreateMap<Features, FeaturesToReturnDto>();
            CreateMap<Tags, TagsToReturnDto>();
            CreateMap<Directon, DirectionToReturnDto>();
            CreateMap<Category, CategoryToReturnDto>();
            CreateMap<SubCategory, SubCategoryToReturnDto>();

        }
    }
}