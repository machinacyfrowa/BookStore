using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bookstore.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definiujemy zależności pomiedzy tabelami
            modelBuilder.Entity<Author>()
                //jeden autor ma wiele książek
                .HasMany(a => a.Books)
                //jedna książka ma jednego autora
                .WithOne(b => b.Author)
                //klucz obcy
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
