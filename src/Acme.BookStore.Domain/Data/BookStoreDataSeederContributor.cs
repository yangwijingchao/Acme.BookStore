using Acme.BookStore.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Shared.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Domain.Data
{
    /// <summary>
    /// 创建数据种子
    /// </summary>
    public class BookStoreDataSeederContributor:IDataSeedContributor,ITransientDependency
    {
        // 定义一个IRepository<Book,Guid>类型的私有字段
        private readonly IRepository<Book,Guid> _bookRepository;

        // 构造函数，接收一个IRepository<Book,Guid>类型的参数
        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository)
        {
            // 将参数赋值给私有字段
            _bookRepository = bookRepository;
        }

        // 实现IDataSeedContributor接口的SeedAsync方法
        public async Task SeedAsync(DataSeedContext context)
        {
            // 如果_bookRepository中没有任何书籍
            if(await _bookRepository.GetCountAsync()<=0)
            {
                // 向_bookRepository中插入一本书
                await _bookRepository.InsertAsync(new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949,6,8),
                    Price = 19.84f
                },autoSave:true);

                // 向_bookRepository中插入另一本书
                await _bookRepository.InsertAsync(new Book
                {
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                }, autoSave: true);
            }
        }
    }
}
