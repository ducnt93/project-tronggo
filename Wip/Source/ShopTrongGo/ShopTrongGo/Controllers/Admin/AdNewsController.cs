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
    public class AdNewsController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /News/

        public ActionResult Index()
        {
            var tintucs = db.TinTucs.Include(t => t.DanhMucTin);
            return View(tintucs.ToList());
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id = 0)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            ViewBag.LoaiDMTin = new SelectList(db.DanhMucTins, "Id", "TenDMTin");
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiDMTin = new SelectList(db.DanhMucTins, "Id", "TenDMTin", tintuc.LoaiDMTin);
            return View(tintuc);
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiDMTin = new SelectList(db.DanhMucTins, "Id", "TenDMTin", tintuc.LoaiDMTin);
            return View(tintuc);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiDMTin = new SelectList(db.DanhMucTins, "Id", "TenDMTin", tintuc.LoaiDMTin);
            return View(tintuc);
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tintuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tintuc);
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