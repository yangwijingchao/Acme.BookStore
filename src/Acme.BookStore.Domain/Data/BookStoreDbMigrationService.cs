using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.Domain.Data
{
    /// <summary>
    /// 数据迁移服务
    /// </summary>
    // 定义一个BookStoreDbMigrationService类，实现ITransientDependency接口
    public class BookStoreDbMigrationService:ITransientDependency
    {

        
        // 定义一个DataSeeder类型的_dataSeeder属性
        private readonly DataSeeder _dataSeeder;
        // 定义一个IEnumerable<IBookStoreDbSchemaMigrator>类型的_dbSchemaMigrators属性
        private readonly IEnumerable<IBookStoreDbSchemaMigrator> _dbSchemaMigrators;

        // 构造函数，传入一个IEnumerable<IBookStoreDbSchemaMigrator>和一个DataSeeder类型的参数
        public BookStoreDbMigrationService(IEnumerable<IBookStoreDbSchemaMigrator> dbSchemaMigrators, DataSeeder dataSeeder)
        {
            // 将参数赋值给属性
            _dbSchemaMigrators = dbSchemaMigrators;
            _dataSeeder = dataSeeder;

        }

        // 定义一个异步的MigrateAsync方法
        public async Task MigrateAsync()
        {
            // 遍历_dbSchemaMigrators中的每一个migrator
            foreach (var migrator in _dbSchemaMigrators)
            {
                // 调用migrator的MigrateAsync方法
                await migrator.MigrateAsync();
            }

            // 调用_dataSeeder的SeedAsync方法
            await _dataSeeder.SeedAsync();
        }
    }
}
