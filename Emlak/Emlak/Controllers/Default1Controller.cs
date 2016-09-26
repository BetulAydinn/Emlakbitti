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
    public class Default1Controller : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var ilandısozellik = db.IlanDısOzellik.Include(i => i.DısOzellik).Include(i => i.Ilan);
            return View(ilandısozellik.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            IlanDısOzellik ilandısozellik = db.IlanDısOzellik.Find(id);
            if (ilandısozellik == null)
            {
                return HttpNotFound();
            }
            return View(ilandısozellik);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            ViewBag.DOID = new SelectList(db.DısOzellik, "DOID", "DısOzellik1");
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik");
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IlanDısOzellik ilandısozellik)
        {
            if (ModelState.IsValid)
            {
                db.IlanDısOzellik.Add(ilandısozellik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOID = new SelectList(db.DısOzellik, "DOID", "DısOzellik1", ilandısozellik.DOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandısozellik.IlanID);
            return View(ilandısozellik);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IlanDısOzellik ilandısozellik = db.IlanDısOzellik.Find(id);
            if (ilandısozellik == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOID = new SelectList(db.DısOzellik, "DOID", "DısOzellik1", ilandısozellik.DOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandısozellik.IlanID);
            return View(ilandısozellik);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IlanDısOzellik ilandısozellik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilandısozellik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOID = new SelectList(db.DısOzellik, "DOID", "DısOzellik1", ilandısozellik.DOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilandısozellik.IlanID);
            return View(ilandısozellik);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IlanDısOzellik ilandısozellik = db.IlanDısOzellik.Find(id);
            if (ilandısozellik == null)
            {
                return HttpNotFound();
            }
            return View(ilandısozellik);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IlanDısOzellik ilandısozellik = db.IlanDısOzellik.Find(id);
            db.IlanDısOzellik.Remove(ilandısozellik);
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