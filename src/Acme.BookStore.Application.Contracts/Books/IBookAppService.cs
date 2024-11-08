﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Application.Contracts.Books
{
    public interface IBookAppService: ICrudAppService<BookDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateBookDto,CreateUpdateBookDto>
    {

    }
}
