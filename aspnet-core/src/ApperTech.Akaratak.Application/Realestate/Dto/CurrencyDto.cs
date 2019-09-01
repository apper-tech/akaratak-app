using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class CurrencyDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string Sign { get; set; }

        public string LocalSign { get; set; }
    }
}
