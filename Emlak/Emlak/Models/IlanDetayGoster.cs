using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emlak.Models
{
    public class IlanDetayGoster
    {
        public string IdOdaSayisi { get; set; }
        public string IdBinaYasi { get; set; }
        public string IdBinaKat { get; set; }
        public string IdBinaKacinciKat { get; set; }
        public string IlanBaslik{ get; set; }
        public string IlanFiyat { get; set; }
        public string IlanAciklama { get; set; }
        public string ResimYol { get; set; }

    }
}