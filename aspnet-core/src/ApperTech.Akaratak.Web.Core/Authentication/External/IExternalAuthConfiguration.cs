using System.Collections.Generic;

namespace ApperTech.Akaratak.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
