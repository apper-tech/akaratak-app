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
            CreateMap<SubCategory, CategoryToReturnDto>()
            .ForMember(dest => dest.CategoryName, opt =>
            opt.MapFrom(src => src.SubCategoryName))
            .ForMember(dest => dest.CategoryDescription, opt =>
            opt.MapFrom(src => src.SubCategoryDescription));



        }
    }
}