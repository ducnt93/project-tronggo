using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        Func func = new Func();
        
        #region Login

        public ActionResult Index()
        {
            if (Session["LogedName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","AdminLogin");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(TaiKhoan user)
        {
            //if (ModelState.IsValid)
            //{
                using (var m = new WebBanTapHoaEntities())
                {
                    string pass = func.GetMd5(user.MatKhau);
                    var v =
                        m.TaiKhoans.FirstOrDefault(u => u.TenDangNhap.Equals(user.TenDangNhap) && u.MatKhau.Equals(pass));
                    if (v != null)
                    {
                        Session["LogedName"] = v.TenDangNhap;
                        Session["LogedFullName"] = v.TenNguoiDung;
                        return RedirectToAction("Index","AdminLogin");
                    }
                    return View(user);
                }
            //}
            //
        }

        public ActionResult Logout()
        {
            Session["LogedName"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
        #endregion

    }
}
