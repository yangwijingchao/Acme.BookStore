using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Application
{
   
    [DependsOn(typeof(BookStoreDomainModule),
        typeof(BookStoreApplicationContractsModule))]
    public class BookStoreApplicationModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BookStoreApplicationModule>();
            });
        }
    }
}
