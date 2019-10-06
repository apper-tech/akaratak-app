using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using ApperTech.Akaratak.Authorization.Users;

namespace ApperTech.Akaratak.Authorization.Accounts.Dto
{
    [AutoMapTo(typeof(User))]
    public class UpdateUserInput
    {
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
        [StringLength(25)]
        public string Organization { get; set; }
      
        public string FacebookUrl { get; set; }
     
        public string TwitterUrl { get; set; }
      
        public string InstagramUrl { get; set; }
      
        public string WebsiteUrl { get; set; }
      
        public string LinkedinUrl { get; set; }

    }
}