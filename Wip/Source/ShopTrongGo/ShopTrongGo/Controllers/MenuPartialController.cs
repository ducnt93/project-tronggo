using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class MenuPartialController : Controller
    {
        WebBanTapHoaEntities dbEntities = new WebBanTapHoaEntities();

        [ChildActionOnly]
        public ActionResult MenuTrongRuou()
        {
            ViewBag.MenuLeft = dbEntities.LoaiSanPhams.Where(p => !p.TrangThaiXoa & p.DanhMucID == 1).ToList();
            return PartialView();
        }


        [ChildActionOnly]
        public ActionResult MenuService()
        {
            ViewBag.MenuService = dbEntities.DichVus.Where(dv => !dv.TrangThaiXoa).OrderByDescending(dv => dv.NgayDang).Take(20).ToList();
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MenuQuanAo()
        {
            ViewBag.MenuQuanAo = dbEntities.LoaiSanPhams.Where(l => !l.TrangThaiXoa & l.DanhMucID == 2).ToList();
            return PartialView();
        }


        [ChildActionOnly]
        public ActionResult MenuSua()
        {
            ViewBag.MenuSua = dbEntities.LoaiSanPhams.Where(l => !l.TrangThaiXoa & l.DanhMucID == 3).ToList();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult ProductFeatured()
        {
            ViewBag.ProductFeatured = dbEntities.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.LuotView).Take(5).ToList();
            return PartialView();
        }


        [ChildActionOnly]
        public ActionResult MenuFooter()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MenuBanner()
        {
            List<DanhMuc> danhMucs = dbEntities.DanhMucs.Where(lSp => !lSp.TrangThaiXoa).ToList();
            return PartialView(danhMucs);
        }

        [ChildActionOnly]
        public ActionResult MenuRight()
        {
            List<DanhMuc> danhMucs = dbEntities.DanhMucs.Where(lSp => !lSp.TrangThaiXoa & lSp.DanhMucID != 1).ToList();
            return PartialView(danhMucs);
        }

        [ChildActionOnly]
        public ActionResult MenuSearch()
        {
            return PartialView();
        }
    }
}
