using Abp.AutoMapper;
using ApperTech.Akaratak.Authentication.External;

namespace ApperTech.Akaratak.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
