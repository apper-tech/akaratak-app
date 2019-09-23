using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class RealestateMapProfile : Profile
    {
        public RealestateMapProfile()
        {
            //realestate maps 

            CreateMap<CreateAddressInput, Address>()
                .ForMember(d => d.CityId,
                    opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.City,
                    opt => opt.Ignore());

            CreateMap<CreateOfferInput, Offer>()
                .ForMember(d => d.CurrencyId,
                    opt => opt.MapFrom(s => s.Currency))
                .ForMember(d => d.Currency,
                    opt => opt.Ignore());

            CreateMap<Property, PropertyDto>();

            CreateMap<CreateFeaturesInput, Features>()
                .ForMember(s => s.FeaturesTags, opt => opt.Ignore())
                .ForMember(s => s.Direction, opt => opt.Ignore())
                .AfterMap((input, features, context) =>
                {
                    features.FeaturesTags = new List<FeaturesTag>();
                    foreach (var dir in input.Direction)
                        features.Direction += dir;
                });

            CreateMap<Features, FeaturesDto>()
                .ForMember(d => d.Tags,
                    opt => opt.MapFrom(s =>
                        s.FeaturesTags.Select(y => y.Tag).ToList()));

            CreateMap<City, CityDto>()
                .ForMember(d => d.CountryId,
                    opt => opt.MapFrom(s => s.Country.Id));
        }
    }

}
