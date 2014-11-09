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
    public class AdCatagoryController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();
        Func func = new Func();

        //
        // GET: /AdCatagory/

        public ActionResult Index()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            var danhmucs = db.DanhMucs.Include(d => d.NhaCungCap).Include(d => d.NhaCungCap1);
            return View(danhmucs.ToList());
        }

        //
        // GET: /AdCatagory/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        //
        // GET: /AdCatagory/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.DanhMucID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc");
            ViewBag.NhaCungCapID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc");
            return View();
        }

        //
        // POST: /AdCatagory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(DanhMuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                danhmuc.TenKhongDau = func.ConvertToUnSign3(danhmuc.TenDanhMuc);
                if (danhmuc.TrangThaiXoa == false)
                {
                    danhmuc.NgayXoa = null;
                }
                else
                {
                    danhmuc.NgayXoa = DateTime.Now.Date;
                }
                db.DanhMucs.Add(danhmuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DanhMucID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.DanhMucID);
            ViewBag.NhaCungCapID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.NhaCungCapID);
            return View(danhmuc);
        }

        //
        // GET: /AdCatagory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanhMucID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.DanhMucID);
            ViewBag.NhaCungCapID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.NhaCungCapID);
            return View(danhmuc);
        }

        //
        // POST: /AdCatagory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DanhMuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                danhmuc.TenKhongDau = func.ConvertToUnSign3(danhmuc.TenDanhMuc);
                if (danhmuc.TrangThaiXoa == false)
                {
                    danhmuc.NgayXoa = null;
                }
                else
                {
                    danhmuc.NgayXoa = DateTime.Now.Date;
                }
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMucID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.DanhMucID);
            ViewBag.NhaCungCapID = new SelectList(db.NhaCungCaps, "NhaCungCapID", "TenNcc", danhmuc.NhaCungCapID);
            return View(danhmuc);
        }

        //
        // GET: /AdCatagory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }

        //
        // POST: /AdCatagory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhmuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhmuc);
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