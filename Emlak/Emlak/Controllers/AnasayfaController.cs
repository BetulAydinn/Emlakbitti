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
    public class AnasayfaController : Controller
    {
        //
        // GET: /Anasayfa/
        private emlakEntities6 db = new emlakEntities6();
        public ActionResult Index()
        {
            var ilan = db.Ilan.Include(i => i.Islem).Include(i => i.Kategori).Include(i => i.Kimden);
            return View(ilan.ToList());
        }

    }
}
