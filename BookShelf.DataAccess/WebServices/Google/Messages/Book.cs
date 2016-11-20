using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.DataAccess.WebServices.Google.Messages
{
    public class Book
    {
        public string Id { get; set; }

        public BookVolumeInfo VolumeInfo { get; set; }

    }
   
}