using Acme.BookStore.EntityFrameworkCore.DbMigrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Microsoft.Extensions.Logging;
using Acme.BookStore.Domain.Data;
using Microsoft.Extensions.Logging.Abstractions;
using Castle.Core.Logging;

namespace Acme.BookStore.DbMigrator
{
    public class DbMigratorHostedService:IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DbMigratorHostedService> _logger;

        public DbMigratorHostedService(IConfiguration configuration, IHostApplicationLifetime hostApplicationLifetime, ILogger<DbMigratorHostedService> logger)
        {
            _configuration = configuration;
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var application = AbpApplicationFactory.Create<BookStoreDbMigratorModule>(options =>
                   {
                       options.Services.ReplaceConfiguration(_configuration);
                       options.UseAutofac();
                       options.AddDataMigrationEnvironment();
                   }))
            {
                application.Initialize();
                _logger.LogInformation("开始执行数据迁移......");
                await application.ServiceProvider.GetRequiredService<BookStoreDbMigrationService>().MigrateAsync();
                await application.ShutdownAsync();
                _hostApplicationLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("数据迁移完成......");
            return Task.CompletedTask;
        }
    }
}
