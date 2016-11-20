using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.WebServices.Google.Messages
{
    public class GoogleBook
    {
        public string Id { get; set; }

        public GoogleBookVolumeInfo VolumeInfo { get; set; }
    }

    public class GoogleBookVolumeInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}