using BookShelf.Infrastructure;
using BookShelf.Models;
using BookShelf.ViewModels;

namespace BookShelf.WebServices.Interfaces
{
    public interface IBookService: ITransient
    {
        Book Get(string id);

        PagedResults<Book> Search(string searchTerm, int page = 1);
    }
}
