﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(LoaiSanPhamMetadata))]
    public partial class LoaiSanPham
    {

    }
    public partial class LoaiSanPhamMetadata
    {
        [Required(ErrorMessage = "Nhập tên loại sản phẩm")]
        [DataType(DataType.Text)]
        public string TenLoaiSp { get; set; }
    }
}