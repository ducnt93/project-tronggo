using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(DanhMucTinMetadata))]
    public partial class DanhMucTin
    {

    }
    public partial class DanhMucTinMetadata
    {
        [Required(ErrorMessage = "Nhập tên danh mục tin tức")]
        public string TenDMTin { get; set; }

        [Required(ErrorMessage = "Nhập mô tả danh mục tin tức")]
        public string MoTa { get; set; }
    }
}