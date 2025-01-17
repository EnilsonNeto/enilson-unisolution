using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace EnilsonSolution.Localization
{
    public static class EnilsonSolutionLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(EnilsonSolutionConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(EnilsonSolutionLocalizationConfigurer).GetAssembly(),
                        "EnilsonSolution.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
