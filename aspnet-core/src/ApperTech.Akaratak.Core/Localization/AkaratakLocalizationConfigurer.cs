using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ApperTech.Akaratak.Localization
{
    public static class AkaratakLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AkaratakConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AkaratakLocalizationConfigurer).GetAssembly(),
                        "ApperTech.Akaratak.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
