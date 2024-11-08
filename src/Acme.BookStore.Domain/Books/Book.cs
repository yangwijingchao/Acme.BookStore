using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Shared.Books;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Domain.Books
{
    public class Book:Entity<Guid>
    {
        // 书名
        public string Name { get; set; }

        // 书的类型
        public BookType Type { get; set; }
        // 出版日期
        public DateTime PublishDate { get; set; }

        // 价格
        public float Price { get; set; }
    }
}
