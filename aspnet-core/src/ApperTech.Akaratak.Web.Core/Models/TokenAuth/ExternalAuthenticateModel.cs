using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using ApperTech.Akaratak.Authorization.Accounts.Dto;

namespace ApperTech.Akaratak.Models.TokenAuth
{
    public class ExternalAuthenticateModel : RegisterInput
    {
        [Required]
        [StringLength(2048)]
        public string IdToken { get; set; }
    }
}