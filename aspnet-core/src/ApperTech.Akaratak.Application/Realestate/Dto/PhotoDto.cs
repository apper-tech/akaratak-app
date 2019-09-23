using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Photo))]
    public class PhotoDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        public int PropertyId { get; set; }

        [Required, MinLength(20)]
        public string Url { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public bool IsMain { get; set; }
        [Required, MinLength(10), MaxLength(50)]
        public string PublicId { get; set; }
    }

    public class CreatePhotoInput
    {
        [Required] public string Name { get; set; }
        [Required] public IFormFile File { get; set; }
    }
}