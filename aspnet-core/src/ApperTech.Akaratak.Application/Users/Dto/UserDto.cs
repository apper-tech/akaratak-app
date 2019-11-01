using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ApperTech.Akaratak.Authorization.Users;
using ApperTech.Akaratak.Realestate.Dto;
using Newtonsoft.Json;

namespace ApperTech.Akaratak.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public virtual bool IsActive { get; set; }

        public string FullName { get; set; }

        public virtual DateTime? LastLoginTime { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual string[] RoleNames { get; set; }


        public PhotoDto Photo { get; set; }

        public string PhoneNumber { get; set; }

        public string Organization { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string LinkedinUrl { get; set; }


        public virtual UserType UserType { get; set; }
    }
    [AutoMapFrom(typeof(User))]
    public class ViewUserDto : UserDto
    {
        [JsonIgnore]
        public new long Id { get; set; }
        [JsonIgnore]
        public override bool IsActive { get; set; }
        [JsonIgnore]
        public override DateTime? LastLoginTime { get; set; }
        [JsonIgnore]
        public override DateTime CreationTime { get; set; }
        [JsonIgnore]
        public override string[] RoleNames { get; set; }
        [JsonIgnore]
        public override UserType UserType { get; set; }
    }
}
