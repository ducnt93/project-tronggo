//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoManagerPage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int LoaiSpID { get; set; }
        public string TenLoaiSp { get; set; }
        public bool TrangThaiXoa { get; set; }
        public System.DateTime NgayXoa { get; set; }
        public int DanhMucID { get; set; }
    
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
