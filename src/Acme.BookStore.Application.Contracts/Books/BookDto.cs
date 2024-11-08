using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Shared.Books;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Application.Contracts.Books
{
    public class BookDto:EntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
