using System.ComponentModel.DataAnnotations;

namespace BookShelf.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }
    }
}