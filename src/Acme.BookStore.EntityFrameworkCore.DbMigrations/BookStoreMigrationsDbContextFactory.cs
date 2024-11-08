using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.BookStore.EntityFrameworkCore.DbMigrations
{
    /// <summary>
    /// 用于生成迁移的DbContext工厂,d-migration命令需要
    /// </summary>
    public class BookStoreMigrationsDbContextFactory:IDesignTimeDbContextFactory<BookStoreMigrationsDbContext>
    {
        // 实现IDesignTimeDbContextFactory接口中的CreateDbContext方法
        public BookStoreMigrationsDbContext CreateDbContext(string[] args)
        {
           var configuration = BuildConfiguration();
           string connectionString = configuration.GetConnectionString("BookStore");
           var builder = new DbContextOptionsBuilder<BookStoreMigrationsDbContext>()
               .UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
           return new BookStoreMigrationsDbContext(builder.Options);
           
        }


        private static IConfigurationRoot BuildConfiguration()
        {
            // 读取配置文件
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            return builder.Build();
        }
    }

   
}
