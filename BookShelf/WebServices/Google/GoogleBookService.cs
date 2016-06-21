using BookShelf.WebServices.Interfaces;
using System.Collections.Generic;
using BookShelf.Models;
using BookShelf.ViewModels;
using RestSharp;
using BookShelf.WebServices.Google.Messages;

namespace BookShelf.WebServices.Google
{
    /// <summary>
    /// ref for paging 
    /// https://developers.google.com/books/docs/v1/reference/volumes/list#parameters
    /// </summary>
    public class GoogleBookService : IBookService
    {
        private int maxResults = 40;

        /// <summary>
        /// Example call - https://www.googleapis.com/books/v1/volumes?q=dragon
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public BookSearchResults SearchBooks(string searchTerm, int page = 1)
        {
            string url = "https://www.googleapis.com/books/v1";
            var client = new RestClient(url);
            var request = new RestRequest("volumes", Method.GET);
            request.AddParameter("q", searchTerm);
            request.AddParameter("maxResults", maxResults);
            request.AddParameter("startIndex", (page - 1) * maxResults);
            request.AddHeader("Content-Type", "application/json");
            
            var response = client.Execute<GoogleBookList>(request);

            var books = AutoMapper.Mapper.Map<List<Book>>(response.Data.Items);
            
            var returnValue = new BookSearchResults
            {
                Books = books,
                TotalItems = response.Data.TotalItems
            };

            return returnValue;
        }

      
    }
}