using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Application.Contracts.Books;
using Acme.BookStore.Domain.Books;
using AutoMapper;

namespace Acme.BookStore.Application
{
    public class BookStoreApplicationAutoMapperProfile:Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            CreateMap<BookDto, CreateUpdateBookDto>();


        }
    }
}
