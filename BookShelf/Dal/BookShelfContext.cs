using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookShelf.Models;

namespace BookShelf.Dal
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