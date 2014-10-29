using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(BannerMetadata))]
    public partial class Banner { }
    public partial class BannerMetadata
    {
        [Required(ErrorMessage = "Nhập thứ tự hiển thị")]
        [Range(0,int.MaxValue,ErrorMessage = "Nhập 1 số")]
        public int ThuTuShow { get; set; }

        [Required(ErrorMessage = "Nhập mô tả")]
        public string MoTa { get; set; }
    }
}