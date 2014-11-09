using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdOrderController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /AdOrder/

        public ActionResult Index()
        {
            var hoadons = db.HoaDons.Include(h => h.TaiKhoan);
            return View(hoadons.ToList());
        }

        //
        // GET: /AdOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            HoaDon hoadon = db.HoaDons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        //
        // GET: /AdOrder/Create

        public ActionResult Create()
        {
            ViewBag.TaiKhoanID = new SelectList(db.TaiKhoans, "TaiKhoanID", "TenNguoiDung");
            return View();
        }

        //
        // POST: /AdOrder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HoaDon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TaiKhoanID = new SelectList(db.TaiKhoans, "TaiKhoanID", "TenNguoiDung", hoadon.TaiKhoanID);
            return View(hoadon);
        }

        //
        // GET: /AdOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            HoaDon hoadon = db.HoaDons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.TaiKhoanID = new SelectList(db.TaiKhoans, "TaiKhoanID", "TenNguoiDung", hoadon.TaiKhoanID);
            return View(hoadon);
        }

        //
        // POST: /AdOrder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HoaDon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaiKhoanID = new SelectList(db.TaiKhoans, "TaiKhoanID", "TenNguoiDung", hoadon.TaiKhoanID);
            return View(hoadon);
        }

        //
        // GET: /AdOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            HoaDon hoadon = db.HoaDons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        //
        // POST: /AdOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoadon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoadon);
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