using Acme.BookStore.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Domain;

[DependsOn(typeof(BookStoreDomainSharedModule),
    typeof(AbpLocalizationModule))]
public class BookStoreDomainModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            //options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));

        });

    }
}
