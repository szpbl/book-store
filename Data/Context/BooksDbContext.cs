using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Context
{
    public class BooksDbContext : DbContext
    {
        #region Constructor

        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options) { }

        #endregion

        #region Properties

        public DbSet<Book> Books { get; set; }

        #endregion
    }
}
