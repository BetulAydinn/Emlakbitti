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
    
    public partial class IcOzellik
    {
        public IcOzellik()
        {
            this.IlanIcOzellik = new HashSet<IlanIcOzellik>();
        }
    
        public string IcOzellik1 { get; set; }
        public int IOID { get; set; }
    
        public virtual ICollection<IlanIcOzellik> IlanIcOzellik { get; set; }
    }
}
