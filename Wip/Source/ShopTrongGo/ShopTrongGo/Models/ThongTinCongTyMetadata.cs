using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(ThongTinCongTyMetadata))]
    public partial class ThongTinCongTy
    {

    }
    public partial class ThongTinCongTyMetadata
    {
        [Required(ErrorMessage = "Nhập công ty")]
        [DataType(DataType.Text)]
        public string TenCongTy { get; set; }

        [Required(ErrorMessage = "Nhập email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Nhập địa chỉ hiện tại")]
        [DataType(DataType.Text)]
        public string DiaChi { get; set; }
    }
}