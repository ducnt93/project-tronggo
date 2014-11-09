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
    public class AdOrderDetailsController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /AdOrderDetails/

        public ActionResult Index()
        {
            var chitiethoadons = db.ChiTietHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(chitiethoadons.ToList());
        }

        //
        // GET: /AdOrderDetails/Details/5

        public ActionResult Details(string id = null)
        {
            ChiTietHoaDon chitiethoadon = db.ChiTietHoaDons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadon);
        }

        //
        // GET: /AdOrderDetails/Create

        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID");
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp");
            return View();
        }

        //
        // POST: /AdOrderDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChiTietHoaDon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDons.Add(chitiethoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chitiethoadon.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", chitiethoadon.SanPhamID);
            return View(chitiethoadon);
        }

        //
        // GET: /AdOrderDetails/Edit/5

        public ActionResult Edit(string id = null)
        {
            ChiTietHoaDon chitiethoadon = db.ChiTietHoaDons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chitiethoadon.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", chitiethoadon.SanPhamID);
            return View(chitiethoadon);
        }

        //
        // POST: /AdOrderDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChiTietHoaDon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.HoaDons, "HoaDonID", "HoaDonID", chitiethoadon.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", chitiethoadon.SanPhamID);
            return View(chitiethoadon);
        }

        //
        // GET: /AdOrderDetails/Delete/5

        public ActionResult Delete(string id = null)
        {
            ChiTietHoaDon chitiethoadon = db.ChiTietHoaDons.Find(id);
            if (chitiethoadon == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadon);
        }

        //
        // POST: /AdOrderDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHoaDon chitiethoadon = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chitiethoadon);
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