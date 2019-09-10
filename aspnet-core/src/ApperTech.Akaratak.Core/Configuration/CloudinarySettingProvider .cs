using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Abp.Configuration;

namespace ApperTech.Akaratak.Configuration
{
    public class CloudinarySettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition("CloudinaryCloudName","appertech"),
                new SettingDefinition("CloudinaryApiKey","461559722629522"),
                new SettingDefinition("CloudinaryApiSecret","tIoXcMfz5_M5j1Y087xmYp9D1tA")
            };
        }
    }
}
