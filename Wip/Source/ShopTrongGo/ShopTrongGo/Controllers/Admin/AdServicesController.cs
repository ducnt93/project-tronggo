using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdServicesController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /AdServices/

        public ActionResult Index(int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            int pageNum = trang ?? 1;
            const int pageSize = 10;
            return View(db.DichVus.OrderBy(dv => dv.DichVuID).ToPagedList(pageNum,pageSize));
        }

        //
        // GET: /AdServices/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // GET: /AdServices/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        //
        // POST: /AdServices/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                dichvu.NgayDang = DateTime.Now.Date;
                db.DichVus.Add(dichvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichvu);
        }

        //
        // GET: /AdServices/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /AdServices/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DichVu dichvu)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            if (ModelState.IsValid)
            {
                if (dichvu.TrangThaiXoa)
                {
                    dichvu.NgayXoa = DateTime.Now.Date;
                }
                else
                {
                    dichvu.NgayXoa = null;
                }
                db.Entry(dichvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichvu);
        }

        //
        // GET: /AdServices/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /AdServices/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DichVu dichvu = db.DichVus.Find(id);
            db.DichVus.Remove(dichvu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}