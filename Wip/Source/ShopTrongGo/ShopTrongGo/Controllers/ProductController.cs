using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult All(int id)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa & sp.LoaiSpID == id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            var pro = dbTapHoa.SanPhams.SingleOrDefault(sp => !sp.TrangThaiXoa & sp.SanPhamID == id);
            ViewBag.ListProduct = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).Take(6).ToList();
            return View(pro);
        }
    }
}
