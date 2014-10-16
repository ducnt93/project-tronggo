using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public ActionResult All(int id, int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 3;
            int pageNum = page ?? 1;
            var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == id).OrderBy(p => p.SanPhamID).ToList();
            return View(list.ToPagedList(pageNum,pageSize));
        }
        [HttpGet]
        public ActionResult Details(string id,int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 3;
            int pageNum = page ?? 1;
            var pro = dbTapHoa.SanPhams.SingleOrDefault(sp => !sp.TrangThaiXoa & sp.SanPhamID == id);
            ViewBag.ListProduct = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == pro.LoaiSpID);
            return View(pro);
        }
    }
}
