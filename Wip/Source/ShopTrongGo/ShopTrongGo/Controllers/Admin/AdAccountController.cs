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
    public class AdAccountController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            var taikhoans = db.TaiKhoans.Include(t => t.LoaiTaiKhoan);
            return View(taikhoans.ToList());
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            ViewBag.LoaiTaiKhoanID = new SelectList(db.LoaiTaiKhoans, "LoaiTaiKhoanID", "TenLoai");
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiTaiKhoanID = new SelectList(db.LoaiTaiKhoans, "LoaiTaiKhoanID", "TenLoai", taikhoan.LoaiTaiKhoanID);
            return View(taikhoan);
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiTaiKhoanID = new SelectList(db.LoaiTaiKhoans, "LoaiTaiKhoanID", "TenLoai", taikhoan.LoaiTaiKhoanID);
            return View(taikhoan);
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiTaiKhoanID = new SelectList(db.LoaiTaiKhoans, "LoaiTaiKhoanID", "TenLoai", taikhoan.LoaiTaiKhoanID);
            return View(taikhoan);
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        //
        // POST: /Account/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taikhoan);
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