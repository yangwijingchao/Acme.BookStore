using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain;
using Acme.BookStore.Domain.Shared;
using Acme.BookStore.EntityFrameworkCore.DbMigrations;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.BookStore.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BookStoreEntityFrameworkCoreDbMigrationsModule),
        typeof(BookStoreDomainModule),
        typeof(BookStoreDomainSharedModule))]
    public class BookStoreDbMigratorModule:AbpModule
    {
    }
}
