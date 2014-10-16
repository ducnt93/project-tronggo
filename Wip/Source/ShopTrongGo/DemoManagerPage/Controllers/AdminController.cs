using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoManagerPage.Models;

namespace DemoManagerPage.Controllers
{
    public class AdminController : Controller
    {
        private WebTapHoaEntities db = new WebTapHoaEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var sanphams = db.SanPhams.Include(s => s.LoaiSanPham);
            return View(sanphams.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
            return View(sanpham);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
            return View(sanpham);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiSpID = new SelectList(db.LoaiSanPhams, "LoaiSpID", "TenLoaiSp", sanpham.LoaiSpID);
            return View(sanpham);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(string id = null)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanpham);
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