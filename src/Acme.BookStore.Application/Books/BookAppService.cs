using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Books;
using Acme.BookStore.Domain.Books;
using Acme.BookStore.Domain.Shared.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Application.Books
{
    public class BookAppService: CrudAppService<Book,BookDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateBookDto>, IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository) : base(repository)
        {
            //LocalizationResource = typeof(BookStoreResource);
        }

        
    }
}
