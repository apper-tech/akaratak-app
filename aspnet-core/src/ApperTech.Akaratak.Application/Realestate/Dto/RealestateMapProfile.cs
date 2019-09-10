using System.Collections.Generic;
using Abp.Timing;
using AutoMapper;
using Castle.MicroKernel.SubSystems.Conversion;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class RealestateMapProfile : Profile
    {
        public RealestateMapProfile()
        {
            //realestate maps 

            CreateMap<CreateAddressInput, Address>()
                .ForPath(s => s.City.Id,
                    opt => opt.MapFrom(d => d.City));

            CreateMap<CreateOfferInput, Offer>()
                .ForPath(s => s.Currency.Id,
                opt => opt.MapFrom(d => d.Currency));

            CreateMap<Property, PropertyDto>();


            CreateMap<CreateFeaturesInput, Features>()
                .ForMember(s => s.Tags, opt => opt.Ignore())
                .ForMember(s => s.Direction, opt => opt.Ignore())
                .AfterMap((input, features) =>
                {
                    features.Tags = new List<Tag>();
                    foreach (var inputTag in input.Tags)
                        features.Tags.Add(new Tag { Id = inputTag });
                    foreach (var dir in input.Direction)
                        features.Direction += dir;
                });

            CreateMap<City, CityDto>()
                .ForMember(d => d.CountryId,
                    opt => opt.MapFrom(s => s.Country.Id));

        }
    }

}
