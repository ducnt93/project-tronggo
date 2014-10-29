using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(DanhMucAnhMetadata))]
    public  partial class DanhMucAnh
    {
        
    }
    public partial class DanhMucAnhMetadata
    {
        [Required(ErrorMessage = "Tải ảnh lên")]
        [DataType(DataType.ImageUrl)]
        public string TenAnh { get; set; }
    }
}