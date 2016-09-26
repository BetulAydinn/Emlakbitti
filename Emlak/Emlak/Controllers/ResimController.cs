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
    public class ResimController : Controller
    {
        private emlakEntities6 db = new emlakEntities6();

        //
        // GET: /Resim/

        public ActionResult Index()
        {
            var resim = db.Resim.Include(r => r.Ilan);
            return View(resim.ToList());
        }

        //
        // GET: /Resim/Details/5

        public ActionResult Details(int id = 0)
        {
            Resim resim = db.Resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        //
        // GET: /Resim/Create

        public ActionResult Create()
        {
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik");
            return View();
        }

        //
        // POST: /Resim/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resim resim, HttpPostedFileBase file)
        {
            if (file != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/images/"+ ResimAdi);
                file.SaveAs(adres);

                resim.ResimAd = Request.Form["ResimAd"];
                resim.ResimYol = ResimAdi;

            }

            if (ModelState.IsValid)
            {
                db.Resim.Add(resim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", resim.IlanID);
            return View(resim);
        }

        //
        // GET: /Resim/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Resim resim = db.Resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", resim.IlanID);
            return View(resim);
        }

        //
        // POST: /Resim/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resim resim, HttpPostedFileBase file)
        {


            if (file != null)
            {

                string ResimAdi = System.IO.Path.GetFileName(file.FileName);
                string adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                resim.ResimAd = Request.Form["ResimAd"];
                resim.ResimYol = ResimAdi;

            }

            if (ModelState.IsValid)
            {
                db.Entry(resim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IlanID = new SelectList(db.Ilan, "IlanID", "IlanBaslik", resim.IlanID);
            return View(resim);
        }

        //
        // GET: /Resim/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Resim resim = db.Resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        //
        // POST: /Resim/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resim resim = db.Resim.Find(id);
            db.Resim.Remove(resim);
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