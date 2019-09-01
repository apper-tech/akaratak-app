using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class RealestateMapProfile : Profile
    {
        public RealestateMapProfile()
        {
            //realestate maps 
            CreateMap<City, CityDto>()
                .ForMember(d => d.CountryId,
                    opt => opt.MapFrom(s => s.Country.Id));
        }
    }
}
