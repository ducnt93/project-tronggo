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
    
    public partial class ChiTietHoaDon
    {
        public string SanPhamID { get; set; }
        public int HoaDonID { get; set; }
        public int SoLuongMua { get; set; }
        public double Gia { get; set; }
        public bool TrangThaiXoa { get; set; }
        public Nullable<System.DateTime> NgayXoa { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
