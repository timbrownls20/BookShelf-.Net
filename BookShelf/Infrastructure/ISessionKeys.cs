using BookShelf.DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShelf.MVC.Infrastructure
{
    public interface ISessionKeys: ITransient
    {
        string SearchTerm { get; set; }
        int? CurrentPage { get; set; }
    }
}