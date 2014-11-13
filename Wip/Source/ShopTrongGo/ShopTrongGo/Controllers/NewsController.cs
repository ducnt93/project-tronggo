using System.Linq;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        readonly WebBanTapHoaEntities _dbBanTapHoaEntities = new WebBanTapHoaEntities();

        public ActionResult AllNews(int? trang)
        {
            const int pageSize = 15;
            int pageNum = trang ?? 1;
            var listNews = _dbBanTapHoaEntities.TinTucs.Where(tt => tt.TrangThai == true).OrderByDescending(tt => tt.NgayCapNhat);
            return View(listNews.ToPagedList(pageNum, pageSize));
        }

        public ActionResult DetailNews(int? id)
        {
            var tinTuc = _dbBanTapHoaEntities.TinTucs.SingleOrDefault(tt => tt.TrangThai==true & tt.Id == id);
            ViewBag.DanhSachTin =
                _dbBanTapHoaEntities.TinTucs.Where(tt => tt.TrangThai & tt.Id != id)
                    .OrderByDescending(tt => tt.NgayCapNhat)
                    .Take(15)
                    .ToList();
            return View(tinTuc);
        }

        public ActionResult AllServices(int? trang)
        {
            const int pageSize = 15;
            int pageNum = trang ?? 1;
            var listServices = _dbBanTapHoaEntities.DichVus.Where(dv => !dv.TrangThaiXoa).OrderByDescending(dv => dv.NgayDang);
            return View(listServices.ToPagedList(pageNum, pageSize));
        }

        public ActionResult DetailServices(int id)
        {
            var dichVu = _dbBanTapHoaEntities.DichVus.SingleOrDefault(dv => !dv.TrangThaiXoa & dv.DichVuID == id);
            ViewBag.DanhSachDichVu =
                _dbBanTapHoaEntities.DichVus.Where(dv => !dv.TrangThaiXoa & dv.DichVuID != id)
                    .OrderByDescending(tt => tt.NgayDang)
                    .Take(15)
                    .ToList();
            return View(dichVu);
        }
    }
}
