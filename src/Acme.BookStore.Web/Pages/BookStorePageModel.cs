using Acme.BookStore.Domain.Shared.Localization.BookStore;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages
{
    public class BookStorePageModel:AbpPageModel
    {
        public BookStorePageModel()
        {
            LocalizationResourceType = typeof(BookStoreResource);

        }
    }
}
