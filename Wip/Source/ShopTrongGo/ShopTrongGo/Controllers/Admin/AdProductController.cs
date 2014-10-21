using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdProductController : Controller
    {
  

        #region My Account
        public ActionResult InformationAccount()
        {           
            if (Session["LogedName"] != null)
            {
                var db = new WebBanTapHoaEntities();
                var tk = new TaiKhoan();
                tk.TenDangNhap = Session["LogedName"].ToString();
                var taikhoan = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap.Equals(tk.TenDangNhap));
                if (taikhoan == null)
                {
                    return HttpNotFound();
                }
                return View(taikhoan);
                }
            else
            {
                return RedirectToAction("Login","Login");
            }       
        }

        public ActionResult ChangePassword()
        {
            if (Session["LogedName"] != null)
            {
                var db = new WebBanTapHoaEntities();
                var tk = new TaiKhoan();
                tk.TenDangNhap = Session["LogedName"].ToString();
                var taikhoan = db.TaiKhoans.FirstOrDefault(u => u.TenDangNhap.Equals(tk.TenDangNhap));
                if (taikhoan == null)
                {
                    return HttpNotFound();
                }
                return View(taikhoan);
            }
            else
            {
                return RedirectToAction("Login","Login");
            }                                          
        }          
        #endregion

        #region Manage Product
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();
        public ActionResult ListProduct()
        {
            if (Session["LogedName"] != null)
            {
                var sanphams = db.SanPhams.Include("LoaiSanPham");
                return View(sanphams.ToList());
            }
            return RedirectToAction("Login","AdminLogin");
        }

        public ActionResult AddProduct()
        {
            if (Session["LogedName"] != null)
            {
                ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp");
                return View();
            }
            return RedirectToAction("Login","AdminLogin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddProduct(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("ListProduct");
            }

            ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
            return View(sanpham);
        }

        public ActionResult EditProduct(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (Session["LogedName"] != null)
            {
                if (sanpham == null)
                {
                    return HttpNotFound();
                }
                ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
                return View(sanpham);
            }
            return RedirectToAction("Login", "AdminLogin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditProduct(SanPham sanpham)
        {
            if (Session["LogedName"] != null)
            {
                if (ModelState.IsValid)
                {
                    sanpham.NgayCapNhat = DateTime.Now.Date;
                    if (sanpham.TrangThaiXoa == true)
                    {
                        sanpham.NgayXoa = DateTime.Now.Date;
                    }
                    db.Entry(sanpham).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ListProduct", "AdProduct");
                }
                ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
                return View(sanpham);
            }
            return RedirectToAction("Login", "AdminLogin");
        }

        public ActionResult DetailsProduct(string id = null)
        {
            if (Session["LogedName"] != null)
            {
                SanPham sanpham = db.SanPhams.Find(id);
                if (sanpham == null)
                {
                    return HttpNotFound();
                }
                return View(sanpham);
            }
            return RedirectToAction("Login","AdminLogin");
        }

        public ActionResult DeleteProduct(string id = null)
        {
            if (Session["LogedName"] != null)
            {
                SanPham sanpham = db.SanPhams.Find(id);
                if (sanpham == null)
                {
                    return HttpNotFound();
                }
                return View(sanpham);
            }
            return RedirectToAction("Login","AdminLogin");
        }

        //
        // POST: /MngProduct/Delete/5

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]                
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index","AdminLogin");
        }
        #endregion
    }
}
