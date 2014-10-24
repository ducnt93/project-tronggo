using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTrongGo.Models
{
    public class Contact
    {
        [Display(Name = "Tên của bạn")]
        [Required(ErrorMessage = "Tên không được trống")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng")]
        public string Email { get; set; }
        [Display(Name = "Sô điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được trống")]
        public string Phone { get; set; }
        [Display(Name = "Chủ đề")]
        [Required(ErrorMessage = "Chủ đề không được trống")]
        public string Subject { get; set; }
        [Display(Name = "Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}