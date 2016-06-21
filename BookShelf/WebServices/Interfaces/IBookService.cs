using BookShelf.Infrastructure;
using BookShelf.ViewModels;

namespace BookShelf.WebServices.Interfaces
{
    public interface IBookService: ITransient
    {
        BookSearchResults SearchBooks(string searchTerm, int page = 1);
    }
}
