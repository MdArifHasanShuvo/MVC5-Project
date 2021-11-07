using PublisherAndBooks.Models;
using PublisherAndBooks.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublisherAndBooks.Controllers
{
    public class BooksController : Controller
    {
        readonly BookAndPublisherDbContext db = new BookAndPublisherDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        //Create section
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Publishers = db.Publishers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookViewModel b)
        {
            if (ModelState.IsValid)
            {
                Book bk = new Book { Title = b.Title, Genre = b.Genre, Publish = b.Publish, PublisherID = b.PublisherID, Rating = b.Rating, Picture = "demo.jpg" };
                if (b.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(b.Picture.FileName);
                    b.Picture.SaveAs(Server.MapPath("~/Pictures/") + fileName);
                    bk.Picture = fileName;
                }
                db.Books.Add(bk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Publishers = db.Publishers.ToList();
            return View(b);
        }
        //Edit section
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Publishers = db.Publishers.ToList();
            var bk = db.Books.First(x => x.BookId == id);
            ViewBag.Pic = bk.Picture;
            return View(new BookViewModel { BookId = bk.BookId, Title = bk.Title, Genre = bk.Genre, Rating = bk.Rating, Publish = bk.Publish, PublisherID = bk.PublisherID });
        }
        [ValidateAntiForgeryToken] // Not others fields add
        [HttpPost]
        public ActionResult Edit(BookViewModel b)
        {
            var bk = db.Books.First(x => x.BookId == b.BookId);

            if (ModelState.IsValid)
            {
                bk.Title = b.Title;
                bk.Genre = b.Genre;
                bk.Rating = b.Rating;
                bk.Publish = b.Publish;
                bk.PublisherID = b.PublisherID;
                if (b.Picture != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(b.Picture.FileName);
                    b.Picture.SaveAs(Server.MapPath("~/Pictures/") + fileName);
                    bk.Picture = fileName;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pic = bk.Picture;
            ViewBag.Publishers = db.Publishers.ToList();
            return View(b);
        }
        //Delete section
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Books.First(x => x.BookId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int id)
        {
            Book ph = new Book { BookId = id };
            db.Entry(ph).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}