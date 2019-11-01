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

            CreateMap<UpdateAddressInput, Address>()
                .ForMember(d => d.CityId,
                    opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.City,
                    opt => opt.Ignore());

            CreateMap<CreateOfferInput, Offer>()
                .ForMember(d => d.CurrencyId,
                    opt => opt.MapFrom(s => s.Currency))
                .ForMember(d => d.Currency,
                    opt => opt.Ignore());

            CreateMap<UpdateOfferInput, Offer>()
                .ForMember(d => d.CurrencyId,
                    opt => opt.MapFrom(s => s.Currency))
                .ForMember(d => d.Currency,
                    opt => opt.Ignore());

            CreateMap<CreateFeaturesInput, Features>()
                .AfterMap((input, features) => features.FeaturesTags = new List<FeaturesTag>());

            CreateMap<UpdateFeaturesInput, Features>()
                .AfterMap((input, features) => features.FeaturesTags = new List<FeaturesTag>());

            CreateMap<CreatePropertyInput, Property>()
                .ForMember(d => d.PropertyTypeId,
                    opt => opt.MapFrom(s => s.PropertyType))
                .ForMember(d => d.PropertyType,
                    opt => opt.Ignore());

            CreateMap<UpdatePropertyInput, Property>()
                .ForMember(d => d.PropertyTypeId,
                    opt => opt.MapFrom(s => s.PropertyType))
                .ForMember(d => d.PropertyType,
                    opt => opt.Ignore());

            CreateMap<Features, FeaturesDto>()
                .ForMember(d => d.Tags,
                    opt => opt.MapFrom(s =>
                        s.FeaturesTags.Select(y => y.Tag).ToList()));

            CreateMap<City, CityDto>()
                .ForMember(d => d.CountryId,
                    opt => opt.MapFrom(s => s.Country.Id));

            CreateMap<Property, PropertyDto>()
                .ForMember(d => d.Lister,
                    opt => opt.MapFrom(s => s.CreatorUser));
        }
    }

}
