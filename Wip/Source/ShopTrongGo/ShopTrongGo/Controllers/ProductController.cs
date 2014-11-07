using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult All(int idDm, int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var id = int.Parse(Session["AllPro"].ToString());
            if (id == 1)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderBy(p => p.TenSp);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderBy(p => p.Gia);
                return View(list.OrderByDescending(p => p.Gia).ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }

        [HttpPost]
        public ActionResult All(int idDm, int? page, FormCollection form)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            Session["AllPro"] = form["dropdown"];
            var id = int.Parse(Session["AllPro"].ToString());
            if (id == 1)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderBy(p => p.TenSp);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderBy(p => p.Gia);
                return View(list.OrderByDescending(p => p.Gia).ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == idDm).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }

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
            const int pageSize = 9;
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
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var listProduct =
                dbEntities.SanPhams.Where(
                    sp => !sp.TrangThaiXoa & sp.TenSp.Contains(keyword) || sp.SanPhamID.Contains(keyword)).OrderByDescending(sp => sp.SanPhamID);
            return View(listProduct.ToPagedList(pageNum, pageSize));
        }
    }
}
