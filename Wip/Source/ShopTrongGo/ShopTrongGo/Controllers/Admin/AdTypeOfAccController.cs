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
    public class AdTypeOfAccController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /TypeOfAcc/

        public ActionResult Index()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(db.LoaiTaiKhoans.ToList());
        }

        //
        // GET: /TypeOfAcc/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // GET: /TypeOfAcc/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        //
        // POST: /TypeOfAcc/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiTaiKhoan loaitaikhoan)
        {
            if (ModelState.IsValid)
            {
                db.LoaiTaiKhoans.Add(loaitaikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaitaikhoan);
        }

        //
        // GET: /TypeOfAcc/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // POST: /TypeOfAcc/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiTaiKhoan loaitaikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaitaikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaitaikhoan);
        }

        //
        // GET: /TypeOfAcc/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            if (loaitaikhoan == null)
            {
                return HttpNotFound();
            }
            return View(loaitaikhoan);
        }

        //
        // POST: /TypeOfAcc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiTaiKhoan loaitaikhoan = db.LoaiTaiKhoans.Find(id);
            db.LoaiTaiKhoans.Remove(loaitaikhoan);
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