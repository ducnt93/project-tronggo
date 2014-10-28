﻿using System;
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
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();

        //
        // GET: /Partners/

        public ActionResult Index()
        {
            return View(db.DoiTacs.ToList());
        }

        //
        // GET: /Partners/Details/5

        public ActionResult Details(int id = 0)
        {
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