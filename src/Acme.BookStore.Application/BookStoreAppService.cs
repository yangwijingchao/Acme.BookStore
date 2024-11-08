using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Shared.Localization.BookStore;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application
{
    public class BookStoreAppService : ApplicationService
    {
        public BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
        }
    }
}
