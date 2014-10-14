using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).Take(3).ToList();
            return View(list);
        }

    }
}
