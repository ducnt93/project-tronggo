using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;
using PagedList.Mvc;
namespace ShopTrongGo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        //[HttpGet]
        public ActionResult All(int id, int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 3;
            int pageNum = page ?? 1;
            var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == id).OrderBy(p => p.SanPhamID).ToList();
            return View(list.ToPagedList(pageNum, pageSize));
        }
        [HttpGet]
        public ActionResult Details(string id, int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var sanPham = dbTapHoa.SanPhams.SingleOrDefault(sp => sp.SanPhamID == id);
            if (sanPham != null)
            {
                double luotView = Convert.ToDouble(sanPham.LuotView);
                luotView += 1;
                sanPham.LuotView = luotView;
                dbTapHoa.SaveChanges();
            }
            ViewBag.ListProduct = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == sanPham.LoaiSpID).OrderByDescending(sp => sp.NgayCapNhat).ToPagedList(pageNum, pageSize);
            ViewBag.ListImage = dbTapHoa.DanhMucAnhs.Where(a => !a.TrangThaiXoa & a.SanPhamID == id).ToList();
            return View(sanPham);
        }

        public ActionResult ProductFeatured()
        {
            var dbEntities = new WebBanTapHoaEntities();
            var listProductFeatured = dbEntities.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.LuotView).Take(20).ToList();
            return View(listProductFeatured);
        }

        [HttpPost]
        public ActionResult SearchProducts(FormCollection form, int? page)
        {
            Session["search"] = form["seach"];
            string keyword = form["seach"];
            var dbEntities = new WebBanTapHoaEntities();
            const int pageSize = 3;
            int pageNum = page ?? 1;
            var listProduct =
                dbEntities.SanPhams.Where(
                    sp => !sp.TrangThaiXoa & sp.TenSp.Contains(keyword) || sp.SanPhamID.Contains(keyword)).OrderByDescending(sp => sp.SanPhamID);
            return View(listProduct.ToPagedList(pageNum, pageSize));
        }

        [HttpGet]
        public ActionResult SearchProducts(int? page)
        {
            string keyword = Session["search"].ToString();
            var dbEntities = new WebBanTapHoaEntities();
            const int pageSize = 3;
            int pageNum = page ?? 1;
            var listProduct =
                dbEntities.SanPhams.Where(
                    sp => !sp.TrangThaiXoa & sp.TenSp.Contains(keyword) || sp.SanPhamID.Contains(keyword)).OrderByDescending(sp => sp.SanPhamID);
            return View(listProduct.ToPagedList(pageNum, pageSize));
        }
    }
}
