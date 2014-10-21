using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        #region Login

        public ActionResult Index()
        {
            if (Session["LogedName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                using (var m = new WebBanTapHoaEntities())
                {
                    var v =
                        m.TaiKhoans.FirstOrDefault(u => u.TenDangNhap.Equals(user.TenDangNhap) && u.MatKhau.Equals(user.MatKhau));
                    if (v != null)
                    {
                        Session["LogedName"] = v.TenDangNhap;
                        Session["LogedFullName"] = v.TenNguoiDung;
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["LogedName"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}
