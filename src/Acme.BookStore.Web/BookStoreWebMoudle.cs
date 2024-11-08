using Acme.BookStore.Application;
using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Domain;
using Acme.BookStore.Domain.Shared;
using Acme.BookStore.Domain.Shared.Localization.BookStore;
using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Web.Menus;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security;
using Volo.Abp.SecurityLog;
using Volo.Abp.Settings;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Acme.BookStore.Web
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(BookStoreApplicationModule),
        typeof(BookStoreEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
        typeof(AbpSwashbuckleModule))]
    public class BookStoreWebMoudle : AbpModule
    {
       

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(BookStoreResource)
                , typeof(BookStoreDomainModule).Assembly
                , typeof(BookStoreDomainSharedModule).Assembly
                , typeof(BookStoreApplicationModule).Assembly
                , typeof(BookStoreApplicationContractsModule).Assembly
                , typeof(BookStoreWebMoudle).Assembly
                );
            });

            //PreConfigure<AbpAntiForgeryOptions>(options =>
            //{
            //    //options.TokenCookie.Expiration = TimeSpan.FromDays(365);
            //    options.AutoValidate = false;
            //});

        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            //全局禁用防伪令牌验证
            //context.Services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            //}).InitializeTagHelper<FormTagHelper>((helper, context) => helper.Antiforgery = false);

            Configure<AbpAntiForgeryOptions>(options =>
            {
                //options.TokenCookie.Expiration = TimeSpan.FromDays(365);
                //options.AutoValidate = false;
                options.AutoValidateIgnoredHttpMethods.Add("POST");
            });


            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(LeptonXLiteThemeBundles.Styles.Global,
                    bundle =>
                    {
                        bundle.AddFiles("/global-styles.css");
                    });
            });
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<BookStoreWebMoudle>();
            });
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<BookStoreWebMoudle>();
                if (hostingEnvironment.IsDevelopment())
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Acme.BookStore.Domain.Shared", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Acme.BookStore.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Acme.BookStore.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Acme.BookStore.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<BookStoreWebMoudle>(hostingEnvironment.ContentRootPath);
                }
            });
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BookStoreMenuContributor());
            });
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BookStoreApplicationModule).Assembly);
            });



            context.Services.AddAbpSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
                options.DocInclusionPredicate((dovName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });


           


        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
           
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAbpRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
            });
            app.UseConfiguredEndpoints();
        }
    }
}
