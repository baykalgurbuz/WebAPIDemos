using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebAPIDemos.Controllers.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var contex = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!contex.Books.Any())
                {
                    contex.Books.AddRange(new Models.Book()
                    {
                        Title = "1 st Title",
                        Description = "1st Book Description",
                        IsRead= true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genre="Biography",
                        Author="First Outhor",
                        CoverUrl="https....",
                        DateAdded=DateTime.Now,
                    },
                    new Models.Book()
                    {
                        Title = "2 st Title",
                        Description = "2st Book Description",
                        IsRead = true,
                        Genre = "Biography",
                        Author = "Second Outhor",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now,
                    }

                    );
                    contex.SaveChanges();
                }
            }
        }
    }
}
