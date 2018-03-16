using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBooksSite.Models;
using MyBooksSite.ViewModels;

namespace MyBooksSite.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).ToList();
            var ratings = db.Ratings.ToList();
            var viewModel = new List<BookRatingViewModel>();
            viewModel = CalculateBookRating(books, ratings, viewModel);
            return View(viewModel);
        }

        [AllowAnonymous]
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new BookRatingViewModel(); 
            viewModel.Book = db.Books.Find(id);
            var ratings = from rating in db.Ratings
                           where rating.BookId == viewModel.Book.Id
                           select rating.Stars;
            
            if (ratings.Count() > 0)
            {
                viewModel.AverageRating = ratings.Average();
            }
            if (viewModel.Book == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
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
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Books/Delete/5
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Helpers
        private List<BookRatingViewModel> CalculateBookRating(List<Book> books, List<Rating> ratings, List<BookRatingViewModel> viewModel)
        {
            foreach (var book in books)
            {
                var newBookRating = new BookRatingViewModel();
                newBookRating.Book = book;
                var count = 0;
                var total = 0;
                foreach (var rating in ratings)
                {
                    if (book.Id == rating.BookId)
                        total += rating.Stars;
                    count++;
                }
                if (count > 0)
                {
                    newBookRating.AverageRating = total / count;
                }
                else
                {
                    newBookRating.AverageRating = 0;
                }
                viewModel.Add(newBookRating);
            }
            return viewModel;
        }
        #endregion
    }
}
