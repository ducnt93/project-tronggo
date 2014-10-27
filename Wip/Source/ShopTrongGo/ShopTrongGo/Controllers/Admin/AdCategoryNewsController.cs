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
    public class AdCategoryNewsController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /CategoryNews/

        public ActionResult Index()
        {
            return View(db.DanhMucTins.ToList());
        }

        //
        // GET: /CategoryNews/Details/5

        public ActionResult Details(int id = 0)
        {
            DanhMucTin danhmuctin = db.DanhMucTins.Find(id);
            if (danhmuctin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuctin);
        }

        //
        // GET: /CategoryNews/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CategoryNews/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMucTin danhmuctin)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucTins.Add(danhmuctin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhmuctin);
        }

        //
        // GET: /CategoryNews/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DanhMucTin danhmuctin = db.DanhMucTins.Find(id);
            if (danhmuctin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuctin);
        }

        //
        // POST: /CategoryNews/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucTin danhmuctin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuctin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhmuctin);
        }

        //
        // GET: /CategoryNews/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DanhMucTin danhmuctin = db.DanhMucTins.Find(id);
            if (danhmuctin == null)
            {
                return HttpNotFound();
            }
            return View(danhmuctin);
        }

        //
        // POST: /CategoryNews/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMucTin danhmuctin = db.DanhMucTins.Find(id);
            db.DanhMucTins.Remove(danhmuctin);
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