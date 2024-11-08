using Acme.BookStore.Domain.Shared.Localization.BookStore;
using Volo.Abp.UI.Navigation;

namespace Acme.BookStore.Web.Menus
{
    public class BookStoreMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<BookStoreResource>();
            if (context.Menu.Name == StandardMenus.Main)
            {
                var test = l["Menu:BookStore"];
                context.Menu.AddItem(new ApplicationMenuItem("BooksStore", l["Menu:BookStore"], icon: "fa fa-book")
                    .AddItem(new ApplicationMenuItem("BookStore.Books", l["Menu:Books"], url: "/Books")));
            }
            
            return Task.CompletedTask;
        }
    }
}
