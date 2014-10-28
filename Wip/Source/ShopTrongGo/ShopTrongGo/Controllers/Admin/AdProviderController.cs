using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdProviderController : Controller
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

        public ActionResult AddProvider()
        {
            if (Session["LogedName"] != null)
            {               
                return View();
            }
            return RedirectToAction("Login", "AdminLogin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddProvider(NhaCungCap provider)
        {
            return View();
        }
        public ActionResult DeleteProvider(string id = null)
        {
            if (Session["LogedName"] != null)
            {
                NhaCungCap ncc = db.NhaCungCaps.Find(id);
                if (ncc == null)
                {
                    return HttpNotFound();
                }
                return View(ncc);
            }
            return RedirectToAction("Login", "AdminLogin");
        }

        //
        // POST: /MngProduct/Delete/5

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("ListProvider", "Provider");
        }
    }
}
