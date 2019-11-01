using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Realestate.Dto
{
    [AutoMapFrom(typeof(Direction))]
    public class DirectionDto : IEntityDto<int>
    {
        public virtual int Id { get; set; }
        [Required]
        public bool West { get; set; }
        [Required]
        public bool East { get; set; }
        [Required]
        public bool North { get; set; }
        [Required]
        public bool South { get; set; }
    }
    [AutoMapTo(typeof(Direction))]
    public class CreateDirectionDto : DirectionDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
    [AutoMapTo(typeof(Direction))]
    public class UpdateDirectionDto : DirectionDto
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
}
