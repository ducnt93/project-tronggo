using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(TinTucMetadata))]
    public partial class TinTuc
    {

    }
    public class TinTucMetadata
    {
        [Required(ErrorMessage = "Nhập tên bài")]
        [DataType(DataType.Text)]
        public string TenTin { get; set; }

        [Required(ErrorMessage = "Nhập miêu tả ngắn")]
        [MaxLength(200, ErrorMessage = "Độ dài lớn nhất là 200 ký tự")]
        [DataType(DataType.Text)]
        public string MieuTaNgan { get; set; }

        [Required(ErrorMessage = "Nhập chi tiết tin tức")]
        [MinLength(200, ErrorMessage = "Độ dài ngắn nhất là 200 ký tự")]
        public string MieuTaChiTiet { get; set; }

        [Required(ErrorMessage = "Nhập tên tác giả hoặc người đăng bài")]
        public string NguoiDang { get; set; }

        [DataType(DataType.ImageUrl)]
        public string AnhDaiDien { get; set; }

    }
}