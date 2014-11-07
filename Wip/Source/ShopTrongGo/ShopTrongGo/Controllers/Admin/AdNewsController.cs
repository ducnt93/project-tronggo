using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
           
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.StatusSortParm = sortOrder == "true" ? "false_desc" : "Category";

            if (searchString != null)
            {
                trang = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tintucs = from s in db.TinTucs
                         select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    tintucs = tintucs.Where(s => s.TenLoaiSp.ToUpper().Contains(searchString.ToUpper()));
            //}
            //switch (sortOrder)
            //{
            //    case "id_desc":
            //        tintucs = tintucs.OrderByDescending(s => s.LoaiSpID);
            //        break;
            //    case "Category":
            //        tintucs = tintucs.OrderBy(s => s.DanhMuc.TenDanhMuc);
            //        break;
            //    case "category_desc":
            //        tintucs = tintucs.OrderByDescending(s => s.DanhMuc.TenDanhMuc);
            //        break;
            //    case "Name":
            //        tintucs = tintucs.OrderBy(s => s.TenLoaiSp);
            //        break;
            //    case "name_desc":
            //        tintucs = tintucs.OrderByDescending(s => s.TenLoaiSp);
            //        break;
            //    default:  // Name ascending 
            //        tintucs = tintucs.OrderBy(s => s.LoaiSpID);
            //        break;
            //}
            const int pageSize = 10;
            int pageNum = trang ?? 1;
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