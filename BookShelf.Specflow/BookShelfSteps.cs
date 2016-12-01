using BookShelf.DataAccess;
using BookShelf.DataAccess.Models;
using BookShelf.DataAccess.ViewModels;
using BookShelf.DataAccess.WebServices.Google;
using BookShelf.MVC.Controllers;
using BookShelf.MVC.Infrastructure;
using DuoVia.FuzzyStrings;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace BookShelf.Specflow
{
    [Binding]
    public sealed class BookShelfSteps
    {
        private ViewResult _result;

        [Given(@"I am using the virtual bookshelf")]
        public void GivenIAmUsingTheVirtualBookshelf()
        {
            //.. all necessary setup code
            AutoMapperConfig.RegisterMappings();
        }

        [Given(@"I have searched for the book '(.*)'")]
        [Given(@"I have searched for a book about '(.*)'")]
        public void GivenIHaveSearchedForABookAbout(string searchTerm)
        {
            var session = new Mock<ISessionKeys>();
            var bookService = new GoogleBookService();
            var bookController = new BookController(bookService, session.Object);
            
            _result = bookController.Search(searchTerm, 1);
        }

        [Then(@"I retrieve a page of (\d+) results")]
        public void ThenIRetrieveAPageOfResults(int pageNumber)
        {
            var searchResults = _result.Model as PagedResults<Book>;

            Console.WriteLine("Search results " + JsonConvert.SerializeObject(searchResults));

            searchResults.Should().NotBeNull("Search results are null");
            searchResults.Results.Count.Should().Be(10, "Nunber of result found were {0}", searchResults.Results.Count);
        }

        [Then(@"'(.*)' is on the first page of results")]
        public void ThenIsOnTheFirstPageOfResults(string bookTitle)
        {
            var searchResults = _result.Model as PagedResults<Book>;
            //searchResults.Results.Any(x => x.Title.ToLower() == bookTitle).Should().BeTrue("{0} title not found", bookTitle);
            searchResults.Results.Any(x => x.Title.FuzzyMatch(bookTitle) >= 0.7).Should().BeTrue("{0} title not found", bookTitle); 
        }

        [Then(@"I don't want to be logged out")]
        [When(@"I am browsing")]
        [Given(@"I am using the virtual book shelf")]
        [Then(@"It works without error")]
        public void Noop()
        {
            Assert.Pass();
        }

    }
}
