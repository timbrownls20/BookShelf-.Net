using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.DataAccess.WebServices.Google.Messages
{
    public class BookList
    {
        public int TotalItems { get; set; }

        public List<Book> Items { get; set; }
    }
}