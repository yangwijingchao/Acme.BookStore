using Volo.Abp.Domain;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Validation.Localization;
using Acme.BookStore.Domain.Shared.Localization.BookStore;

namespace Acme.BookStore.Domain.Shared
{

    public class BookStoreDomainSharedModule: AbpModule
    {
       

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BookStoreDomainSharedModule>();
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<BookStoreResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("Localization/BookStore/Resources");
                options.DefaultResourceType = typeof(BookStoreResource);

            });
        }
    }
}
