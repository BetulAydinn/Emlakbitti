using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emlak.Models;

namespace Emlak.Controllers
{
    public class IslemController : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /Islem/

        public ActionResult Index()
        {
            return View(db.Islem.ToList());
        }

        //
        // GET: /Islem/Details/5

        public ActionResult Details(int id = 0)
        {
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            return View(islem);
        }

        //
        // GET: /Islem/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Islem/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Islem islem)
        {
            if (ModelState.IsValid)
            {
                db.Islem.Add(islem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(islem);
        }

        //
        // GET: /Islem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            return View(islem);
        }

        //
        // POST: /Islem/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Islem islem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(islem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(islem);
        }

        //
        // GET: /Islem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Islem islem = db.Islem.Find(id);
            if (islem == null)
            {
                return HttpNotFound();
            }
            return View(islem);
        }

        //
        // POST: /Islem/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Islem islem = db.Islem.Find(id);
            db.Islem.Remove(islem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}