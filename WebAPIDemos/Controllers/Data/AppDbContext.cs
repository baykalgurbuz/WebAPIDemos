using Microsoft.EntityFrameworkCore;
using WebAPIDemos.Controllers.Data.Models;

namespace WebAPIDemos.Controllers.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
              .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
             .HasOne(a => a.Author)
             .WithMany(ba => ba.Book_Authors)
             .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
