using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using ApperTech.Akaratak.Authorization.Users;

namespace ApperTech.Akaratak.Realestate
{
    [Table("AppProperty")]
    public class Property : FullAuditedEntity<int, User>, IEntityDto<int>
    {
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }


        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }


        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        [ForeignKey("Features")]
        public int FeaturesId { get; set; }
        public Features Features { get; set; }

        [ForeignKey("Photo")]
        public ICollection<Photo> Photos { get; set; }


        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ListingDate { get; set; } = Clock.Now;

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public int Views { get; set; }
        public string ExtraData { get; set; }
    }
}
