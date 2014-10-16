using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderBy(p => p.SanPhamID);
            return View(list.ToPagedList(pageNum,pageSize));
        }

    }
}
