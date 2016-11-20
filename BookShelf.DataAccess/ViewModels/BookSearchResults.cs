using System.Collections.Generic;
using BookShelf.Models;

namespace BookShelf.ViewModels
{
    public class BookSearchResults
    {
        public List<Book> Books { get; set; }

        public int TotalItems { get; set; }
    }
}