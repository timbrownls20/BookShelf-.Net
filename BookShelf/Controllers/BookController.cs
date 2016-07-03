using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShelf.Dal;
using BookShelf.Models;
using BookShelf.ViewModels;
using BookShelf.WebServices.Interfaces;

namespace BookShelf.Controllers
{
    public class BookController : Controller
    {
        private BookShelfContext db = new BookShelfContext();
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create(string id)
        {
            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    return View("Save");
            //}
            //else
            //{
            var book = bookService.Get(id);
            return View("Save", book);
            //}
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BookID,Title,ISBN")] Book book)
        public ActionResult Create(Book book, List<Author> authors)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Save", book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Save", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BookID,Title,ISBN")] Book book)
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Search(string searchTerm, int? currentPage)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View();
            }
            else
            {
                Session["SearchTerm"] = searchTerm;
                Session["CurrentPage"] = currentPage;

                var viewModel = bookService.Search(searchTerm, currentPage.GetValueOrDefault(1));
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            Session["SearchTerm"] = searchTerm;
            var viewModel = bookService.Search(searchTerm, 1);
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
