using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    public class PhotoDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        [Required, MinLength(20)]
        public string Url { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string PublicId { get; set; }
    }

    public class CreatePhotoInput : PhotoDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}