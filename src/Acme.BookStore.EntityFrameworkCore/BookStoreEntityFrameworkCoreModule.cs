using Acme.BookStore.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Acme.BookStore.EntityFrameworkCore
{
    [DependsOn(typeof(BookStoreDomainModule),
        typeof(AbpEntityFrameworkCoreMySQLModule))]
    public class BookStoreEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookStoreDbContext>(options =>
            {
                options.AddDefaultRepositories(true);
            });
            
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }
        
        
    }
}
