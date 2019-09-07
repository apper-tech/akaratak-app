using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        public ICollection<PropertyTypeDto> PropertyTypes { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
    }
}