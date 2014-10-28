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
    public class AdInforCompanyController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /InforCompany/

        public ActionResult Index()
        {
            return View(db.ThongTinCongTies.ToList());
        }

        //
        // GET: /InforCompany/Details/5

        public ActionResult Details(int id = 0)
        {
            ThongTinCongTy thongtincongty = db.ThongTinCongTies.Find(id);
            if (thongtincongty == null)
            {
                return HttpNotFound();
            }
            return View(thongtincongty);
        }

        //
        // GET: /InforCompany/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InforCompany/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThongTinCongTy thongtincongty)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinCongTies.Add(thongtincongty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongtincongty);
        }

        //
        // GET: /InforCompany/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ThongTinCongTy thongtincongty = db.ThongTinCongTies.Find(id);
            if (thongtincongty == null)
            {
                return HttpNotFound();
            }
            return View(thongtincongty);
        }

        //
        // POST: /InforCompany/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThongTinCongTy thongtincongty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtincongty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongtincongty);
        }

        //
        // GET: /InforCompany/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ThongTinCongTy thongtincongty = db.ThongTinCongTies.Find(id);
            if (thongtincongty == null)
            {
                return HttpNotFound();
            }
            return View(thongtincongty);
        }

        //
        // POST: /InforCompany/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinCongTy thongtincongty = db.ThongTinCongTies.Find(id);
            db.ThongTinCongTies.Remove(thongtincongty);
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