//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emlak.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Islem
    {
        public Islem()
        {
            this.Ilan = new HashSet<Ilan>();
        }
    
        public int IslemID { get; set; }
        public string IslemAd { get; set; }
    
        public virtual ICollection<Ilan> Ilan { get; set; }
    }
}
