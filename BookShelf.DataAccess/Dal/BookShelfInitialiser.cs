using System.Collections.Generic;

namespace BookShelf.DataAccess.Dal
{
    //public class BookShelfInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookShelfContext>
    public class BookShelfInitializer : System.Data.Entity.CreateDatabaseIfNotExists<BookShelfContext>
    {
        protected override void Seed(BookShelfContext context)
        {
            //var books = new List<Book>
            //{
            //    new Book {Title = " Game of Thrones", ISBN_10 = "001"}
            //};

            //books.ForEach(b => context.Books.Add(b));
            //context.SaveChanges();
        }
    }
}