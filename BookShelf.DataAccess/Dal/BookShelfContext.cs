using BookShelf.DataAccess.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BookShelf.DataAccess.Dal
{
    public class BookShelfContext : DbContext
    {

        public BookShelfContext() : base("BookShelfContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}