using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class AccountController : Controller
    {
        private WebBanTapHoaEntities dbBanTapHoaEntities = new WebBanTapHoaEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            string fullName = form["txtFullName"];
            string userName = form["txtUserName"];
            string pass = form["txtPass"];
            string mail = form["txtEmail"];
            string repass = form["txtRePass"];
            string address = form["txtAddress"];
            string phone = form["txtPhone"];
            TaiKhoan taiKhoan =
                dbBanTapHoaEntities.TaiKhoans.SingleOrDefault(tk => tk.TrangThaiXoa == false & tk.TenDangNhap == userName);
            if (taiKhoan != null)
            {
                ViewBag.CheckRegister = "Tài khoản này đã tồn tại";
                return View();
            }
            else
            {
                taiKhoan = new TaiKhoan
                {
                    TenDangNhap = userName,
                    LoaiTaiKhoanID = 2,
                    TrangThaiXoa = false,
                    MatKhau = pass,
                    Email = mail,
                    Phone = phone,
                    DiaChi = address,
                    TenNguoiDung = fullName
                };
                dbBanTapHoaEntities.TaiKhoans.Add(taiKhoan);
                dbBanTapHoaEntities.SaveChanges();
                Session["FullName"] = fullName;
                Session["UserName"] = userName;
                return RedirectToAction("RegisterSuccess");
            }
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string userName = form["txtUserName"];
            string pass = form["txtPass"];
            var taiKhoan =
                dbBanTapHoaEntities.TaiKhoans.SingleOrDefault(
                    tk => !tk.TrangThaiXoa & tk.TenDangNhap == userName & tk.MatKhau == pass);
            if (taiKhoan != null)
            {
                Session["FullName"] = taiKhoan.TenNguoiDung;
                Session["UserName"] = userName;
                if (taiKhoan.LoaiTaiKhoanID == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var cart = Session["Cart"];
                    if (cart != null)
                    {
                        return RedirectToAction("Cart", "ShoppingCart");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            else
            {
                Session["CheckLogin"] = "Kiểm tra lại tên đăng nhập hoặc mật khẩu!";
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpGet]
        public ActionResult ForgotPass()
        {
            //var taikhoan = new TaiKhoan();
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPass(TaiKhoan model)
        {
            var taikhoan = dbBanTapHoaEntities.TaiKhoans.SingleOrDefault(tk => !tk.TrangThaiXoa & tk.Email == model.Email);
            if (taikhoan == null)
            {
                ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng kiểm tra lại địa chỉ email.");
            }
            else
            {
                const string smtpUserName = "ducnt.ts24@gmail.com";
                const string smtpPassword = "11101993";
                const string smtpHost = "smtp.gmail.com";
                const int smtpPort = 25;

                string emailTo = model.Email;
                const string subject = "Lấy lại mật khẩu";
                string body = string.Format("Mật khẩu của bạn là: <b>{0}</b><br/>",
                    taikhoan.MatKhau);

                var service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Kiểm tra lại email để lấy lại mật khẩu.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }

        public ActionResult RePassSuccess()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["FullName"] = "bạn!";
            Session["UserName"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}
