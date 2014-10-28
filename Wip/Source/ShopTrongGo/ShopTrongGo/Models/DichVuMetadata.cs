using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(DichVuMetadata))]
    public partial class DichVu
    {

    }
    public partial class DichVuMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Ngày đăng không được để trống")]
        public System.DateTime NgayDang { get; set; }
        [Required(ErrorMessage = "Người đăng không được để trống")]
        public string NguoiDang { get; set; }
        public string TenDichVu { get; set; }
        [Required(ErrorMessage = "Không nên để trống")]
        public string MieuTaNgan { get; set; }
    }

}