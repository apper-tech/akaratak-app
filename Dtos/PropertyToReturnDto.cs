using System;
using System.Collections.Generic;
using akaratak_app.Models;

namespace akaratak_app.Dtos
{
    public class PropertyToReturnDto
    {
        public int ID { get; set; }

        public AddressToReturnDto Address { get; set; }

        public SubCategoryToReturnDto SubCategory { get; set; }

        public OfferToReturnDto Offer { get; set; }

        public FeaturesToReturnDto Features { get; set; }
        public Listing Listing { get; set; }

        public DateTime ListingDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime PublishDate { get; set; }
        public int Views { get; set; }
        public string ExtraData { get; set; }
    }
}