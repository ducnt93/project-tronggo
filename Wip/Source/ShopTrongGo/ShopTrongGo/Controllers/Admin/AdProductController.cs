using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdProductController : Controller
    {
        Func func = new Func();

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
                return RedirectToAction("Login","AdminLogin");
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
                return RedirectToAction("Login","AdminLogin");
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
                var dstrangthai = new List<SelectListItem>();
                dstrangthai.Add(new SelectListItem { Text = "Còn hàng", Value = "Còn hàng" });
                dstrangthai.Add(new SelectListItem { Text = "Hết hàng", Value = "Hết hàng" });
                dstrangthai.Add(new SelectListItem { Text = "Đăng nhập", Value = "Đăng nhập" });
                ViewData["TrangThai"] = dstrangthai;
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
                sanpham.NgayCapNhat = DateTime.Now;
                sanpham.LuotView = 0;
                sanpham.LuotBan = 0;
                sanpham.TrangThaiXoa = false;
                sanpham.NgayXoa = null;
                sanpham.TenKhongDau = func.ConvertToUnSign3(sanpham.TenSp);
                sanpham.AnhDaiDien = func.LinkImage(sanpham.AnhDaiDien);
                int s = sanpham.LoaiSpID;
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
                    if (sanpham.TrangThaiXoa)
                    {
                        sanpham.NgayXoa = DateTime.Now.Date;
                    }
                    else sanpham.NgayXoa = null;
                    sanpham.TenKhongDau = func.ConvertToUnSign3(sanpham.TenSp);
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
