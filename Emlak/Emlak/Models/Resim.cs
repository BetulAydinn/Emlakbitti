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
    
    public partial class Resim
    {
        public int ResimID { get; set; }
        public string ResimAd { get; set; }
        public Nullable<int> IlanID { get; set; }
        public string ResimYol { get; set; }
    
        public virtual Ilan Ilan { get; set; }
    }
}
