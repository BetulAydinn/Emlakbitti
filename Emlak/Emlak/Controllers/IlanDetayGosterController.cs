using Emlak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emlak.Controllers
{
    public class IlanDetayGosterController : Controller
    {
        //
        // GET: /IlanDetayGoster/
        private emlakEntities6 db = new emlakEntities6();
        public ActionResult Index(int id)
        {
            var query = (from i in db.Ilan
                         join ID in db.IlanDetay on i.IlanID equals ID.IlanID
                         join r in db.Resim on i.IlanID equals r.IlanID where r.IlanID==id

                         select new IlanDetayGoster
                         {

                             IdOdaSayisi=ID.IdOdaSayisi,
                             IdBinaYasi=ID.IdBinaYasi,
                             IdBinaKat=ID.IdBinaKat,
                             IdBinaKacinciKat=ID.IdBinaKacinciKat,
                             IlanBaslik=i.IlanBaslik,
                             IlanFiyat=i.İlanFiyat,
                             IlanAciklama=i.IlanAciklama,
                             ResimYol=r.ResimYol

                         }).ToList();



            return View(query);
        }

    }
}
