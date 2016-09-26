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
    public class IcOzelliklerController : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /IcOzellikler/

        public ActionResult Index()
        {
            var ilanicozellik = db.IlanIcOzellik.Include(i => i.IcOzellik).Include(i => i.Ilan);
            return View(ilanicozellik.ToList());
        }

        //
        // GET: /IcOzellikler/Details/5

        public ActionResult Details(int id = 0)
        {
            IlanIcOzellik ilanicozellik = db.IlanIcOzellik.Find(id);
            if (ilanicozellik == null)
            {
                return HttpNotFound();
            }
            return View(ilanicozellik);
        }

        //
        // GET: /IcOzellikler/Create

        public ActionResult Create()
        {
            ViewBag.IOID = new SelectList(db.IcOzellik, "IOID", "IcOzellik1");
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik");
            return View();
        }

        //
        // POST: /IcOzellikler/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IlanIcOzellik ilanicozellik)
        {
            if (ModelState.IsValid)
            {
                db.IlanIcOzellik.Add(ilanicozellik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IOID = new SelectList(db.IcOzellik, "IOID", "IcOzellik1", ilanicozellik.IOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilanicozellik.IlanID);
            return View(ilanicozellik);
        }

        //
        // GET: /IcOzellikler/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IlanIcOzellik ilanicozellik = db.IlanIcOzellik.Find(id);
            if (ilanicozellik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IOID = new SelectList(db.IcOzellik, "IOID", "IcOzellik1", ilanicozellik.IOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilanicozellik.IlanID);
            return View(ilanicozellik);
        }

        //
        // POST: /IcOzellikler/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IlanIcOzellik ilanicozellik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilanicozellik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IOID = new SelectList(db.IcOzellik, "IOID", "IcOzellik1", ilanicozellik.IOID);
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", ilanicozellik.IlanID);
            return View(ilanicozellik);
        }

        //
        // GET: /IcOzellikler/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IlanIcOzellik ilanicozellik = db.IlanIcOzellik.Find(id);
            if (ilanicozellik == null)
            {
                return HttpNotFound();
            }
            return View(ilanicozellik);
        }

        //
        // POST: /IcOzellikler/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IlanIcOzellik ilanicozellik = db.IlanIcOzellik.Find(id);
            db.IlanIcOzellik.Remove(ilanicozellik);
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