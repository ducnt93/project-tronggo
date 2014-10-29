using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(DanhMucMetadata))]
    public partial class DanhMuc
    {

    }
    public partial class DanhMucMetadata
    {
        [Required (ErrorMessage = "Nhập tên danh mục")]
        public string TenDanhMuc { get; set; }
    }
}