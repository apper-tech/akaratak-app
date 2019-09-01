using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Country))]
    public class CountryDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required, MinLength(2), MaxLength(2)]
        public string Code { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(5), MaxLength(50)]
        public string NativeName { get; set; }

    }
}
