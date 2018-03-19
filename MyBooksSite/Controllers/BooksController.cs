using MyBooksSite.Models;
using MyBooksSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
            return View(books);
        }

        [AllowAnonymous]
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new BookRatingViewModel { AverageRating = 0 }; 
            viewModel.Book = db.Books.Find(id);
            if (viewModel.Book.NumberOfRatings > 0)
            {
                viewModel.AverageRating = Math.Round((double)viewModel.Book.SumRatings / (double)viewModel.Book.NumberOfRatings, 2);
            }
            if (viewModel.Book == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Rate(int id, int rate)
        {
            var bookRating = IncrementBookRating(rate, id);
            return Json(new { averageRating= bookRating.AverageRating, numberOfRatings = bookRating.NumberOfRatings }, JsonRequestBehavior.AllowGet);
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
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FullName", book.AuthorId);
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
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "FullName", book.AuthorId);
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

        [Authorize(Roles = "Admin")]
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
        public BookRatingViewModel IncrementBookRating(int rate, int id)
        {
            var book = db.Books
                      .Where(b => b.Id == id)
                      .First();
            book.SumRatings += rate;
            book.NumberOfRatings++;
            db.SaveChanges();
            var bookRating = new BookRatingViewModel()
            {
                BookId = book.Id,
                SumRatings = book.SumRatings,
                NumberOfRatings = book.NumberOfRatings,
                AverageRating = Math.Round((double)book.SumRatings / (double)book.NumberOfRatings, 2) 
            };
            return bookRating;
        }

        #endregion
    }
}
