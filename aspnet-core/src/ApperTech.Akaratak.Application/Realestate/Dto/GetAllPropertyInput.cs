using System;
using Abp.Application.Services.Dto;
using ApperTech.Akaratak.Configuration;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class FilterPropertyInput
    {
        public PropertySearchParameters PropertySearchParameters { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageNumber { get; set; }

        public int GetSkipCount()
        {
            return this.ItemsPerPage > 1 ? this.ItemsPerPage * this.PageNumber : 0;
        }
    }

    public class PropertySearchParameters
    {
        public int PropertyType { get; set; }

        public OfferPagedResultInput Offers { get; set; }
        public int City { get; set; }

        public string ZipCode { get; set; }

        public Range<float> PriceRange { get; set; }

        public Range<int> BedroomsRange { get; set; }

        public Range<int> BathroomsRange { get; set; }

        public Range<int> AreaRange { get; set; }

        public Range<int> PropertyAgeRange { get; set; }

        public FeaturesSearchParameters Features { get; set; }
    }
}