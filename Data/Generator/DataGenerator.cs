
using BookShop.Data.Context;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookShop.Data.Generator
{
    public class DataGenerator
    {
        public static void InitializeData(IServiceProvider serviceProvider)
        {
            using (var context = new BooksDbContext(serviceProvider.GetRequiredService<DbContextOptions<BooksDbContext>>()))
            {
                if(context.Books.Any())
                { 
                    return; 
                }

                context.Books.AddRange
                    (
                        new Book
                        {
                            Id = 1,
                            Author = "J. R. R. Tolkien",
                            Edition = 1,
                            Publisher = "Harper Collins",
                            Title = "O Hobbit",
                            ISBN = "9788595084742"
                        },
                        new Book
                        {
                              Id = 2,
                              Author = "Felipe Castilho",
                              Edition = 1,
                              Publisher = "Intrínseca",
                              Title = "Serpentário",
                              ISBN = "8551005308"
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
