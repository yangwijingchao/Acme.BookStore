using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore
{
    // 定义一个BookStoreModelCreatingExtensions类
    public static class BookStoreDbContextModelCreatingExtensions
    {
        /// <summary>
        ///  实体上下文配置与迁移配置共同使用 保证一致性
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            // 应用BookMap配置
            builder.ApplyConfiguration(new BookMap());
        }
    }
}
