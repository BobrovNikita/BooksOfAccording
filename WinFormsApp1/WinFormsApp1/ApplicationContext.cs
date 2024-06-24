using WinFormsApp1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace WinFormsApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AccountingOfBooks;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Book
            modelBuilder
                .Entity<Book>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Books)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Book>()
                .HasOne(e => e.Genre)
                .WithMany(e => e.Books)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Book>()
                .HasOne(e => e.Publisher)
                .WithMany(e => e.Books)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
