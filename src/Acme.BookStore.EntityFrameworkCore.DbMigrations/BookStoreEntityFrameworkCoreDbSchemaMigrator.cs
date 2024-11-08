using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.EntityFrameworkCore.DbMigrations
{
    [ExposeServices(typeof(IBookStoreDbSchemaMigrator))]
    public class BookStoreEntityFrameworkCoreDbSchemaMigrator : IBookStoreDbSchemaMigrator,ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public BookStoreEntityFrameworkCoreDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            //数据库迁移
            await _serviceProvider
                .GetRequiredService<BookStoreMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
