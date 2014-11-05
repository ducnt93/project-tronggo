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
    public class AdPartnersController : Controller
    {
        Func func = new Func();
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /Partners/

        public ActionResult Index()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View(db.DoiTacs.ToList());
        }

        //
        // GET: /Partners/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DoiTac doitac = db.DoiTacs.Find(id);
            if (doitac == null)
            {
                return HttpNotFound();
            }
            return View(doitac);
        }

        //
        // GET: /Partners/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        //
        // POST: /Partners/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoiTac doitac)
        {
            if (ModelState.IsValid)
            {
                doitac.NgayCapNhat = DateTime.Now.Date;
                doitac.TenKhongDau = func.ConvertToUnSign3(doitac.TenDoiTac);
                db.DoiTacs.Add(doitac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doitac);
        }

        //
        // GET: /Partners/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DoiTac doitac = db.DoiTacs.Find(id);
            if (doitac == null)
            {
                return HttpNotFound();
            }
            return View(doitac);
        }

        //
        // POST: /Partners/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoiTac doitac)
        {
            if (ModelState.IsValid)
            {
                doitac.NgayCapNhat = DateTime.Now.Date;
                doitac.TenKhongDau = func.ConvertToUnSign3(doitac.TenDoiTac);
                if (doitac.TrangThaiXoa == false)
                {
                    doitac.NgayXoa = null;
                }
                else
                {
                    doitac.NgayXoa = DateTime.Now.Date;
                }
                db.Entry(doitac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doitac);
        }

        //
        // GET: /Partners/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DoiTac doitac = db.DoiTacs.Find(id);
            if (doitac == null)
            {
                return HttpNotFound();
            }
            return View(doitac);
        }

        //
        // POST: /Partners/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoiTac doitac = db.DoiTacs.Find(id);
            db.DoiTacs.Remove(doitac);
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