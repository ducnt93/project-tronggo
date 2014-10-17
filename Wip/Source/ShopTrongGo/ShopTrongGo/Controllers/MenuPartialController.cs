using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class MenuPartialController : Controller
    {
        //
        // GET: /MenuPartial/
        [HttpGet]
        [ChildActionOnly]
        public ActionResult MenuTrongRuou()
        {
            var dbEntities = new WebBanTapHoaEntities();
            ViewBag.MenuLeft = dbEntities.LoaiSanPhams.Where(p => !p.TrangThaiXoa & p.DanhMucID == 1).ToList();
            return PartialView();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult MenuService()
        {
            var dbEntities = new WebBanTapHoaEntities();
            ViewBag.MenuService = dbEntities.LoaiSanPhams.ToList();
            return PartialView();
        }
        [HttpGet]
        [ChildActionOnly]
        public ActionResult MenuQuanAo()
        {
            var dbEntities = new WebBanTapHoaEntities();
            ViewBag.MenuQuanAo = dbEntities.LoaiSanPhams.Where(l => !l.TrangThaiXoa & l.DanhMucID == 2).ToList();
            return PartialView();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult MenuSua()
        {
            var dbEntities = new WebBanTapHoaEntities();
            ViewBag.MenuSua = dbEntities.LoaiSanPhams.Where(l => !l.TrangThaiXoa & l.DanhMucID == 3).ToList();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult ProductFeatured()
        {
            var dbEntities = new WebBanTapHoaEntities();
            ViewBag.ProductFeatured = dbEntities.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => Double.Parse(p.LuotView)).Take(5).ToList();
            return PartialView();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult MenuFooter()
        {
            return PartialView();
        }
    }
}
