using Acme.BookStore.Web;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
await builder.AddApplicationAsync<BookStoreWebMoudle>();
var app = builder.Build();
await app.InitializeApplicationAsync();
//var service = app.Services.GetService<SampleService>();
//await service?.Test();
await app.RunAsync();

