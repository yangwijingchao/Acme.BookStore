using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore.DbMigrations
{
    [ConnectionStringName("BookStore")]
    public class BookStoreMigrationsDbContext:AbpDbContext<BookStoreMigrationsDbContext>
    {
        public DbSet<Book> Books { get; set; }

        public BookStoreMigrationsDbContext(DbContextOptions<BookStoreMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureBookStore();
        }
    }
}
