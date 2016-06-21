using System.Collections.Generic;
using BookShelf.Models;

namespace BookShelf.Dal
{
    public class BookShelfInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookShelfContext>
    {
        protected override void Seed(BookShelfContext context)
        {
            var books = new List<Book>
            {
                new Book {Title = " Game of Thrones", ISBN = "001"}
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}