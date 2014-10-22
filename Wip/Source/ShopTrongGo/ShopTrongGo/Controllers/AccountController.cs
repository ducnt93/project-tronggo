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
                    return RedirectToAction("Index", "AdProduct");
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
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPass(FormCollection form)
        {
            string userName = form["txtUserName"];
            string pass = form["txtPass"];
            string repass = form["txtRePass"];
            TaiKhoan taiKhoan =
                dbBanTapHoaEntities.TaiKhoans.SingleOrDefault(tk => !tk.TrangThaiXoa & tk.TenDangNhap == userName);
            if (taiKhoan != null)
            {
                taiKhoan.MatKhau = pass;
                dbBanTapHoaEntities.SaveChanges();
                return RedirectToAction("RePassSuccess");
            }
            else
            {
                ViewBag.CheckRePass = "Không có tài khoản này! Kiểm tra lại tên đăng nhập";
                return View();
            }

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
