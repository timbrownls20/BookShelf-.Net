using BookShelf.DataAccess;
using BookShelf.DataAccess.Models;
using BookShelf.DataAccess.ViewModels;
using BookShelf.DataAccess.WebServices.Google;
using BookShelf.MVC.Controllers;
using BookShelf.MVC.Infrastructure;
using FluentAssertions;
using Moq;
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
            searchResults.Should().NotBeNull();
            searchResults.Results.Count.Should().Be(10);
        }

        [Then(@"'(.*)' is on the first page of results")]
        public void ThenIsOnTheFirstPageOfResults(string bookTitle)
        {
            var searchResults = _result.Model as PagedResults<Book>;
            searchResults.Results.Any(x => x.Title.ToLower() == bookTitle).Should().BeTrue();
        }


        [Then(@"It works without error")]
        public void ThenItWorksWithoutError()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
