using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(LoaiTaiKhoanMetadata))]
    public partial class LoaiTaiKhoan
    {

    }
    public partial class LoaiTaiKhoanMetadata
    {
        [Required(ErrorMessage = "Nhập tên loại tài khoản")]
        [DataType(DataType.Text)]
        public string TenLoai { get; set; }
    }
}