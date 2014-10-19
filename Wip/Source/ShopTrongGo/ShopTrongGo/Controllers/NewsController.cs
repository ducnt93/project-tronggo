using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using ShopTrongGo.Models;
using PagedList.Mvc;

namespace ShopTrongGo.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        WebBanTapHoaEntities dbBanTapHoaEntities = new WebBanTapHoaEntities();

        public ActionResult AllNews(int? page)
        {
            const int pageSize = 15;
            int pageNum = page ?? 1;
            var listNews = dbBanTapHoaEntities.TinTucs.Where(tt => !tt.TrangThai);
            return View(listNews.ToPagedList(pageNum, pageSize));
        }

        public ActionResult DetailNews(int id)
        {
            var tinTuc = dbBanTapHoaEntities.TinTucs.SingleOrDefault(tt => !tt.TrangThai & tt.Id == id);
            ViewBag.DanhSachTin =
                dbBanTapHoaEntities.TinTucs.Where(tt => !tt.TrangThai)
                    .OrderByDescending(tt => tt.NgayCapNhat)
                    .Take(15)
                    .ToList();
            return View(tinTuc);
        }

        public ActionResult AllServices(int ? page)
        {
            const int pageSize = 15;
            int pageNum = page ?? 1;
            var listServices = dbBanTapHoaEntities.DichVus.Where(dv => !dv.TrangThaiXoa);
            return View(listServices.ToPagedList(pageNum, pageSize));
        }

        public ActionResult DetailServices(int id)
        {
            var dichVu = dbBanTapHoaEntities.DichVus.SingleOrDefault(tt => !tt.TrangThaiXoa & tt.DichVuID == id);
            ViewBag.DanhSachDichVu =
                dbBanTapHoaEntities.DichVus.Where(tt => !tt.TrangThaiXoa)
                    .OrderByDescending(tt => tt.NgayDang)
                    .Take(15)
                    .ToList();
            return View(dichVu);
        }
    }
}
