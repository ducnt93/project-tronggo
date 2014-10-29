using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    [MetadataType(typeof(NhaCungCapMetadata))]
    public partial class NhaCungCap
    {

    }
    public partial class NhaCungCapMetadata
    {
        [Required(ErrorMessage = "Nhập tên Nhà cung cấp")]
        [DataType(DataType.Text)]
        public string TenNcc { get; set; }

        [Required(ErrorMessage = "Nhập số điện thoại của Nhà cung cấp")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Nhập đại chỉ của Nhà cung cấp")]
        [DataType(DataType.Text)]
        public string DiaChi { get; set; }
    }
}