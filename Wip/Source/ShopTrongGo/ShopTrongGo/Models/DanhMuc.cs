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
    
    public partial class DanhMuc
    {
        public DanhMuc()
        {
            this.LoaiSanPhams = new HashSet<LoaiSanPham>();
        }
    
        public int DanhMucID { get; set; }
        public string TenDanhMuc { get; set; }
        public int NhaCungCapID { get; set; }
        public bool TrangThaiXoa { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
        public string TenKhongDau { get; set; }
    
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
