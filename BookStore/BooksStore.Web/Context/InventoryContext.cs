using BooksStore.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Web.Context
{
    public class InventoryContext : DbContext
    {
        #region Public Properties

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        #region Constructors

        public InventoryContext() { }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        #endregion
    }
}
