//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopTrongGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhMucTin
    {
        public DanhMucTin()
        {
            this.TinTucs = new HashSet<TinTuc>();
        }
    
        public int Id { get; set; }
        public string TenDMTin { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
    
        public virtual ICollection<TinTuc> TinTucs { get; set; }
    }
}
