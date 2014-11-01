using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(TaiKhoanMetadata))]
    public partial class TaiKhoan
    {

    }
    public partial class TaiKhoanMetadata
    {
        [Required(ErrorMessage = "Nhập tên người dùng")]
        [DataType(DataType.Text)]
        public string TenNguoiDung { get; set; }

        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [DataType(DataType.Text)]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Độ dài ngắn nhất là 6 ký tự")]
        public string MatKhau { get; set; }

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