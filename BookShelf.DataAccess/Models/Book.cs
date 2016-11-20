using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookShelf.DataAccess.Models
{
    public class Book
    {
        public int? BookID { get; set; }

        /// <summary>
        /// ID corresponding to original retrieval from source
        /// </summary>
        public string BookIDSource { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayName("ISBN 10")]
        public string ISBN_10 { get; set; }

        [DisplayName("ISBN 13")]
        public string ISBN_13 { get; set; }

        //[UIHint("tinymce_jquery_full"), AllowHtml]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string Description { get; set; }

        public decimal Rating { get; set; }

        public int PageCount { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        [DataType(DataType.ImageUrl)]
        public string SmallThumbnail { get; set; }

        public List<Author> Authors { get; set; }

        public string GetISBN()
        {
            return !string.IsNullOrWhiteSpace(ISBN_13) ? ISBN_13 : ISBN_10;
        }

        //public string GetAuthorsForDisplay()
        //{
        //    var displayNames = Authors.Select(x => x.DisplayName).ToList();
        //    return string.Join(",", displayNames);
        //}
    }
}