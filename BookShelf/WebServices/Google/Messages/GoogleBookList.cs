using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.WebServices.Google.Messages
{
    public class GoogleBookList
    {
        public int TotalItems { get; set; }

        public List<GoogleBook> Items { get; set; }
    }
}