﻿using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(PropertyType))]
    public class PropertyTypeDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        public int CategoryId { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required, MinLength(10), MaxLength(50)]
        public string Description { get; set; }
    }
}