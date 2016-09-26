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
    public class IlanDetayController : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /IlanDetay/

        public ActionResult Index()
        {
            var ilandetay = db.IlanDetay.Include(i => i.Ilan);
            return View(ilandetay.ToList());
        }

        //
        // GET: /IlanDetay/Details/5

        public ActionResult Details(int id = 0)
        {
            IlanDetay ilandetay = db.IlanDetay.Find(id);
            if (ilandetay == null)
            {
                return HttpNotFound();
            }
            return View(ilandetay);
        }

        //
        // GET: /IlanDetay/Create

        public ActionResult Create()
        {
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik");
            return View();
        }

        //
        // POST: /IlanDetay/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IlanDetay ilandetay)
        {
            if (ModelState.IsValid)
            {
                db.IlanDetay.Add(ilandetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandetay.IlanID);
            return View(ilandetay);
        }

        //
        // GET: /IlanDetay/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IlanDetay ilandetay = db.IlanDetay.Find(id);
            if (ilandetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandetay.IlanID);
            return View(ilandetay);
        }

        //
        // POST: /IlanDetay/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IlanDetay ilandetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilandetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandetay.IlanID);
            return View(ilandetay);
        }

        //
        // GET: /IlanDetay/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IlanDetay ilandetay = db.IlanDetay.Find(id);
            if (ilandetay == null)
            {
                return HttpNotFound();
            }
            return View(ilandetay);
        }

        //
        // POST: /IlanDetay/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IlanDetay ilandetay = db.IlanDetay.Find(id);
            db.IlanDetay.Remove(ilandetay);
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