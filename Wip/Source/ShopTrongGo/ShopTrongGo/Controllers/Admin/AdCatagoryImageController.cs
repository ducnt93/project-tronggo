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
    public class AdCatagoryImageController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /AdCatagoryImage/

        public ActionResult Index()
        {
            var danhmucanhs = db.DanhMucAnhs.Include(d => d.SanPham);
            return View(danhmucanhs.ToList());
        }

        //
        // GET: /AdCatagoryImage/Details/5

        public ActionResult Details(int id = 0)
        {
            DanhMucAnh danhmucanh = db.DanhMucAnhs.Find(id);
            if (danhmucanh == null)
            {
                return HttpNotFound();
            }
            return View(danhmucanh);
        }

        //
        // GET: /AdCatagoryImage/Create

        public ActionResult Create()
        {
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp");
            return View();
        }

        //
        // POST: /AdCatagoryImage/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMucAnh danhmucanh)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucAnhs.Add(danhmucanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", danhmucanh.SanPhamID);
            return View(danhmucanh);
        }

        //
        // GET: /AdCatagoryImage/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DanhMucAnh danhmucanh = db.DanhMucAnhs.Find(id);
            if (danhmucanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", danhmucanh.SanPhamID);
            return View(danhmucanh);
        }

        //
        // POST: /AdCatagoryImage/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucAnh danhmucanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmucanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "SanPhamID", "TenSp", danhmucanh.SanPhamID);
            return View(danhmucanh);
        }

        //
        // GET: /AdCatagoryImage/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DanhMucAnh danhmucanh = db.DanhMucAnhs.Find(id);
            if (danhmucanh == null)
            {
                return HttpNotFound();
            }
            return View(danhmucanh);
        }

        //
        // POST: /AdCatagoryImage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucAnh danhmucanh = db.DanhMucAnhs.Find(id);
            db.DanhMucAnhs.Remove(danhmucanh);
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