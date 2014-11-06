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
    public class AdNewsController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /News/

        readonly Func fun = new Func();
        public ActionResult Index(int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            const int pageSize = 10;
            int pageNum = trang ?? 1;
            var tintucs = db.TinTucs.Include(t => t.DanhMucTin).OrderByDescending(tin => tin.NgayCapNhat);
            return View(tintucs.ToPagedList(pageNum,pageSize));
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
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
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.LoaiDMTin = new SelectList(db.DanhMucTins, "Id", "TenDMTin");
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                tintuc.NgayCapNhat = DateTime.Now.Date;
                tintuc.TrangThai = false;
                tintuc.NgayXoaTin = null;
                tintuc.TenKhongDau = fun.ConvertToUnSign3(tintuc.TenTin);
                tintuc.AnhDaiDien = fun.LinkImage(tintuc.AnhDaiDien);
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
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
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
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                if (tintuc.TrangThai)
                {
                    tintuc.NgayXoaTin = DateTime.Now.Date;
                }
                else
                {
                    tintuc.NgayXoaTin = null;
                }                                                                          
                tintuc.TenKhongDau = fun.ConvertToUnSign3(tintuc.TenTin);
                tintuc.AnhDaiDien = fun.LinkImage(tintuc.AnhDaiDien);
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
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
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