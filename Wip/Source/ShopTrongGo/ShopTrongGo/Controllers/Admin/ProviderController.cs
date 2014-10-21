using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class ProviderController : Controller
    {
        //
        // GET: /NhaCungCap/

        WebBanTapHoaEntities db = new WebBanTapHoaEntities();
        public ActionResult ListProvider()
        {
            if (Session["LogedName"] != null)
            {
                var ncc = db.NhaCungCaps.Include("DanhMuc");     
                return View(ncc.ToList());
            }
            return RedirectToAction("Login", "AdminLogin");
        }

    }
}
