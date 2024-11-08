using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore.Mappings
{
    // 定义一个BookMap类，实现IEntityTypeConfiguration接口
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        // 实现Configure方法，用于配置Book实体
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // 使用ConfigureByConvention方法，根据约定配置实体
            builder.ConfigureByConvention();
            // 配置Name属性，设置为必填，最大长度为128
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        }
    }
}
