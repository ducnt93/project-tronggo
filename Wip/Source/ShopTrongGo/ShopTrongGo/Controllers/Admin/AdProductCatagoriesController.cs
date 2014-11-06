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
    public class AdProductCatagoriesController : Controller
    {
        Func func = new Func();
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /ProductCatagories/

        public ActionResult ListProductCatagories(int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            const int pageSize = 10;
            int pageNum = trang ?? 1;
            var loaisanphams = db.LoaiSanPhams.Include(l => l.DanhMuc).OrderBy(c => c.DanhMucID);
            return View(loaisanphams.ToPagedList(pageNum,pageSize));
        }

        //
        // GET: /ProductCatagories/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiSanPham loaisanpham = db.LoaiSanPhams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        //
        // GET: /ProductCatagories/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "TenDanhMuc");
            return View();
        }

        //
        // POST: /ProductCatagories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiSanPham loaisanpham)
        {
            if (Session["LogedName"]!=null)
            {
                loaisanpham.TenKhongDau = func.ConvertToUnSign3(loaisanpham.TenLoaiSp);
                db.LoaiSanPhams.Add(loaisanpham);
                db.SaveChanges();
                return RedirectToAction("ListProductCatagories");
            }

            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "TenDanhMuc", loaisanpham.DanhMucID);
            return View(loaisanpham);
        }

        //
        // GET: /ProductCatagories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiSanPham loaisanpham = db.LoaiSanPhams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "TenDanhMuc", loaisanpham.DanhMucID);
            return View(loaisanpham);
        }

        //
        // POST: /ProductCatagories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiSanPham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                loaisanpham.TenKhongDau = func.ConvertToUnSign3(loaisanpham.TenLoaiSp);
                db.Entry(loaisanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListProductCatagories");
            }
            ViewBag.DanhMucID = new SelectList(db.DanhMucs, "DanhMucID", "TenDanhMuc", loaisanpham.DanhMucID);
            return View(loaisanpham);
        }

        //
        // GET: /ProductCatagories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiSanPham loaisanpham = db.LoaiSanPhams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        //
        // POST: /ProductCatagories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiSanPham loaisanpham = db.LoaiSanPhams.Find(id);
            db.LoaiSanPhams.Remove(loaisanpham);
            db.SaveChanges();
            return RedirectToAction("ListProductCatagories");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}