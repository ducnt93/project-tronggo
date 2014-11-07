using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;
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
                return RedirectToAction("Login", "AdminLogin");
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
                return RedirectToAction("Login", "AdminLogin");
            }
        }
        #endregion

        #region Manage Product
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();
        public ActionResult ListProduct(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                ViewBag.TypeSortParm = sortOrder == "Loai" ? "loai_desc" : "Loai";
                ViewBag.ViewSortParm = sortOrder == "LuotView" ? "luotview_desc" : "LuotView";
                ViewBag.PriceSortParm = sortOrder == "Gia" ? "gia_desc" : "Gia";
                ViewBag.StateSortParm = sortOrder == "TrangThai" ? "trangthai_desc" : "TrangThai";
                if (searchString != null)
                {
                    trang = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var sanphams = from s in db.SanPhams
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    sanphams = sanphams.Where(s => s.TenSp.ToUpper().Contains(searchString.ToUpper())
                        || s.LoaiSanPham.TenLoaiSp.ToUpper().Contains(searchString.ToUpper()));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        sanphams = sanphams.OrderByDescending(s => s.TenSp);
                        break;
                    //case "Date":
                    //    sanphams = sanphams.OrderBy(s => s.NgayCapNhat);
                    //    break;
                    //case "date_desc":
                    //    sanphams = sanphams.OrderByDescending(s => s.NgayCapNhat);
                    //    break;
                    case "LuotView":
                        sanphams = sanphams.OrderBy(s => s.LuotView);
                        break;
                    case "luotview_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LuotView);
                        break;
                    case "Loai":
                        sanphams = sanphams.OrderBy(s => s.LoaiSanPham.TenLoaiSp);
                        break;
                    case "loai_desc":
                        sanphams = sanphams.OrderByDescending(s => s.LoaiSanPham.TenLoaiSp);
                        break;
                    case "Gia":
                        sanphams = sanphams.OrderBy(s => s.Gia);
                        break;
                    case "gia_desc":
                        sanphams = sanphams.OrderByDescending(s => s.Gia);
                        break;
                    case "TrangThai":
                        sanphams = sanphams.OrderBy(s => s.TrangThai);
                        break;
                    case "trangthai_desc":
                        sanphams = sanphams.OrderByDescending(s => s.TrangThai);
                        break;
                    default:  // Name ascending 
                        sanphams = sanphams.OrderBy(s => s.TenSp);
                        break;
                }
                const int pageSize = 5;
                int pageNum = trang ?? 1;

                return View(sanphams.ToPagedList(pageNum, pageSize));
            }
            return RedirectToAction("Login", "AdminLogin");
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
            return RedirectToAction("Login", "AdminLogin");
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
            return RedirectToAction("Login", "AdminLogin");
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
            return RedirectToAction("Login", "AdminLogin");
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
            return RedirectToAction("Index", "AdminLogin");
        }
        #endregion

    }
}
