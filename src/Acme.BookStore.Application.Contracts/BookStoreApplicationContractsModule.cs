using Acme.BookStore.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Application.Contracts
{
    [DependsOn(typeof(BookStoreDomainSharedModule))]
    public class BookStoreApplicationContractsModule:AbpModule
    {

    }
}
