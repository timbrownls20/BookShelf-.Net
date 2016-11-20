
using BookShelf.DataAccess.Infrastructure;
using BookShelf.DataAccess.Models;
using BookShelf.DataAccess.ViewModels;

namespace BookShelf.DataAccess.WebServices.Interfaces
{
    public interface IBookService: ITransient
    {
        Book Get(string id);

        PagedResults<Book> Search(string searchTerm, int page = 1);
    }
}
