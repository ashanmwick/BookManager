using BookManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookManager.Db
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}