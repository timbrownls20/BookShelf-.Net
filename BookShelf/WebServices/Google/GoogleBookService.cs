using BookShelf.WebServices.Interfaces;
using System.Collections.Generic;
using BookShelf.Models;
using BookShelf.ViewModels;
using RestSharp;
using Google = BookShelf.WebServices.Google.Messages;

namespace BookShelf.WebServices.Google
{
    /// <summary>
    /// ref for paging 
    /// https://developers.google.com/books/docs/v1/reference/volumes/list#parameters
    /// </summary>
    public class GoogleBookService : IBookService
    {
        private int pageSize = 10;
        private int maxTotal = 200;

        /// <summary>
        /// Example call - https://www.googleapis.com/books/v1/volumes/HzCrngEACAAJ
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Models.Book Get(string id)
        {
            string url = "https://www.googleapis.com/books/v1";
            var client = new RestClient(url);
            var request = new RestRequest("volumes/{volumeid}", Method.GET);
            request.AddUrlSegment("volumeid", id);
            request.AddHeader("Content-Type", "application/json");

            var response = client.Execute<Google.Messages.Book>(request);
            var book = AutoMapper.Mapper.Map<Models.Book>(response.Data);
            return book;
        }

        /// <summary>
        /// Example call - https://www.googleapis.com/books/v1/volumes?q=dragon
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public PagedResults<Models.Book> Search(string searchTerm, int page = 1)
        {
            string url = "https://www.googleapis.com/books/v1";
            var client = new RestClient(url);
            var request = new RestRequest("volumes", Method.GET);
            request.AddParameter("q", searchTerm);
            request.AddParameter("maxResults", pageSize);
            request.AddParameter("startIndex", (page - 1) * pageSize);
            request.AddParameter("orderBy", "relevance");
            request.AddHeader("Content-Type", "application/json");
            
            var response = client.Execute<Google.Messages.BookList>(request);
            var books = AutoMapper.Mapper.Map<List<Models.Book>>(response.Data.Items);
            
            var returnValue = new PagedResults<Models.Book>
            {
                Results = books ?? new List<Models.Book>(),
                TotalItems = response.Data.TotalItems > maxTotal ? maxTotal : response.Data.TotalItems,
                PageSize = pageSize,
                SearchTerm = searchTerm,
                CurrentPage = page
            };

            return returnValue;
        }

      
    }
}