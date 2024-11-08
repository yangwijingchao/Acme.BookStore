using Acme.BookStore.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DbMigratorHostedService>();
var host=builder.Build();
host.Run();