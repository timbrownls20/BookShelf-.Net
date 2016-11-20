using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.DataAccess.WebServices.Google.Messages
{
    public class BookVolumeInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public decimal Rating { get; set; }

        public List<IndustryIdentifier> IndustryIdentifiers { get; set; }

        public ImageLinks ImageLinks { get; set; }

        public List<string> Authors { get; set; }
    }
}