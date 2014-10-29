using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(SanPhamMetadata))]
    public partial class SanPham
    {

    }
    public partial class SanPhamMetadata
    {
        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        [Key]
        public string SanPhamID { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [DataType(DataType.Text)]
        public string TenSp { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(0,int.MaxValue,ErrorMessage = "Nhập 1 số")]
        public decimal Gia { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Nhập 1 số")]
        public int SoLuong { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime NgayXoa { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime NgayCapNhat { get; set; }

        [DataType(DataType.ImageUrl)]
        public string AnhDaiDien { get; set; }

        [Range(0,double.MaxValue)]
        public double LuotBan { get; set; }

        [Range(0, double.MaxValue)]
        public double LuotView { get; set; }

    }
}