using PublisherAndBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublisherAndBooks.Controllers
{
    public class PublishersController : Controller
    {
        // GET: Publishers
        readonly BookAndPublisherDbContext db = new BookAndPublisherDbContext();
        // GET: Publishers
        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }
        //Create section
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Publisher ph)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(ph);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ph);
        }
        //Edit section
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Publishers.First(x => x.PublisherId == id));
        }
        [ValidateAntiForgeryToken] // Not others fields add
        [HttpPost]
        public ActionResult Edit(Publisher ph)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ph).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ph);
        }
        //Delete section
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Publishers.First(x => x.PublisherId == id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int id)
        {
            Publisher ph = new Publisher { PublisherId = id };
            db.Entry(ph).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}