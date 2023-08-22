using Microsoft.EntityFrameworkCore;
using WebAPIDemos.Controllers.Data.Models;

namespace WebAPIDemos.Controllers.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books{ get; set; }
    }
}
