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
    public class IlanController : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /Ilan/

        public ActionResult Index()
        {
            var ilan = db.Ilan.Include(i => i.Islem).Include(i => i.Kategori).Include(i => i.Kimden);
            return View(ilan.ToList());
        }

        //
        // GET: /Ilan/Details/5

        public ActionResult Details(int id = 0)
        {
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        //
        // GET: /Ilan/Create

        public ActionResult Create()
        {
            ViewBag.IslemID = new SelectList(db.Islem, "IslemID", "IslemAd");
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd");
            ViewBag.KimdenID = new SelectList(db.Kimden, "KimdenID", "KimdenAd");
            return View();
        }

        //
        // POST: /Ilan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ilan ilan, HttpPostedFileBase file)
        {

            if (file != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);
                ilan.IlanVResim = ResimAdi;

            }





            if (ModelState.IsValid)
            {
                db.Ilan.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IslemID = new SelectList(db.Islem, "IslemID", "IslemAd", ilan.IslemID);
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", ilan.KategoriID);
            ViewBag.KimdenID = new SelectList(db.Kimden, "KimdenID", "KimdenAd", ilan.KimdenID);
            return View(ilan);
        }

        //
        // GET: /Ilan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IslemID = new SelectList(db.Islem, "IslemID", "IslemAd", ilan.IslemID);
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", ilan.KategoriID);
            ViewBag.KimdenID = new SelectList(db.Kimden, "KimdenID", "KimdenAd", ilan.KimdenID);
            return View(ilan);
        }

        //
        // POST: /Ilan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ilan ilan, HttpPostedFileBase file)
        {



            if (file != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);
                ilan.IlanVResim = ResimAdi;

            }




            if (ModelState.IsValid)
            {
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IslemID = new SelectList(db.Islem, "IslemID", "IslemAd", ilan.IslemID);
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", ilan.KategoriID);
            ViewBag.KimdenID = new SelectList(db.Kimden, "KimdenID", "KimdenAd", ilan.KimdenID);
            return View(ilan);
        }

        //
        // GET: /Ilan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        //
        // POST: /Ilan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilan.Find(id);
            db.Ilan.Remove(ilan);
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