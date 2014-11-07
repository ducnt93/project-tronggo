using System;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class PaymentController : Controller
    {
        readonly WebBanTapHoaEntities dbBanTapHoaEntities = new WebBanTapHoaEntities();
        [HttpGet]
        public ActionResult SendMail()
        {
            //string userName = Session["UserName"].ToString();
            //if (userName == "")
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //else
            //{
                //ViewBag.Mes = "Bạn có chắc chắn muốn mua nhưng sản phẩm này";
                //var taikhoan =
                //    dbBanTapHoaEntities.TaiKhoans.SingleOrDefault(
                //        tk => tk.TrangThaiXoa == false & tk.TenDangNhap == userName & tk.LoaiTaiKhoanID == 2);
                return View();
            //}

        }

        [HttpPost]
        public ActionResult SendMail(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var objCart = (ShoppingCart)Session["Cart"];
                decimal tong = 0;
                const string smtpUserName = "ducnt.ts24@gmail.com";
                const string smtpPassword = "11101993";
                const string smtpHost = "smtp.gmail.com";
                const int smtpPort = 25;
                const string emailTo = "ducnt.ts24@gmail.com";
                string subject = "Đơn đặt hàng ngày " + DateTime.Now.ToString("g");
                string body = string.Format("Bạn vừa nhận được đơn đặt hàng từ: <b>{0}</b><br/>Email: {1}<br/>Số điện thoại:{2}<br/>Địa chỉ:{3}<br/>",
                    taiKhoan.TenNguoiDung, taiKhoan.Email, taiKhoan.Phone, taiKhoan.DiaChi);
                foreach (var product in objCart.ListItem)
                {
                    body += string.Format("<br/>Sản phẩm:<b>{0}</b><br/>Số lượng:<b>{1}</b><br/>Tổng tiền:<b>{2}</b><br/>", product.ProductName, product.Quantity, product.Total.ToString("N0") + "VNĐ");
                    tong += product.Total;
                }
                body += string.Format("<br/>Tổng tiền cần thanh toán:<b>{0}</b><br/>", tong.ToString("N0") + "VNĐ");
                var service = new EmailService();
                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);
                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã mua hàng của chúng tôi. Chúc bạn 1 ngày tốt lành!");
                else ModelState.AddModelError("", "Đơn đặt hàng không gửi được, vui lòng thử lại.");
            }
            return View(taiKhoan);
        }

    }
}
