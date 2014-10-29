using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(DoiTacMetadata))]
    public partial class DoiTac
    {

    }
    public partial class DoiTacMetadata
    {
        [Required(ErrorMessage = "Nhập tên đối tác")]
        [DataType(DataType.Text)]
        public string TenDoiTac { get;set; }

        [Required(ErrorMessage = "Nhập nội dung")]
        [DataType(DataType.Text)]
        public string NoiDung { get; set; }

        [Required(ErrorMessage = "Nhập tên người đăng")]
        [DataType(DataType.Text)]
        public string NguoiDang { get; set; }

        [Required(ErrorMessage = "Nhập miêu tả")]
        [DataType(DataType.Text)]
        public string MieuTaNgan { get; set; }

    }
}