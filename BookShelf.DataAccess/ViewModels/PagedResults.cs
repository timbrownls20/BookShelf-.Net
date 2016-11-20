using System.Collections.Generic;


namespace BookShelf.DataAccess.ViewModels
{
    public class PagedResults<T>
    {
        public List<T> Results { get; set; }

        public int TotalItems { get; set; }

        public string SearchTerm { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int Pages
        {
            get
            {
                if (TotalItems == 0)
                {
                    return 0;
                }
                else
                {
                    return (int)System.Math.Ceiling((decimal)TotalItems / PageSize);
                }
            }
        }
    }
}