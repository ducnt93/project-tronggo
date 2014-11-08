using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers.Admin
{
    public class AdServicesController : Controller
    {
        private WebBanTapHoaEntities db = new WebBanTapHoaEntities();
        Func func = new Func();

        //
        // GET: /AdServices/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Ngay" ? "ngay_desc" : "Loai";
            ViewBag.PeopleSortParm = sortOrder == "Nguoidang" ? "nguoidang_desc" : "LuotView";
            if (searchString != null)
            {
                trang = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var dichvus = from s in db.DichVus
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                dichvus = dichvus.Where(s => s.TenDichVu.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    dichvus = dichvus.OrderByDescending(s => s.TenDichVu);
                    break;
                case "Ngay":
                    dichvus = dichvus.OrderBy(s => s.NgayDang);
                    break;
                case "ngay_desc":
                    dichvus = dichvus.OrderByDescending(s => s.NgayDang);
                    break;
                case "Nguoidang":
                    dichvus = dichvus.OrderBy(s => s.NguoiDang);
                    break;
                case "nguoidang_desc":
                    dichvus = dichvus.OrderByDescending(s => s.NguoiDang);
                    break;
                default:  // Name ascending 
                    dichvus = dichvus.OrderBy(s => s.TenDichVu);
                    break;
            }
            int pageNum = trang ?? 1;
            const int pageSize = 10;
            return View(dichvus.ToPagedList(pageNum,pageSize));
        }

        //
        // GET: /AdServices/Details/5

        public ActionResult Details(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // GET: /AdServices/Create

        public ActionResult Create()
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            return View();
        }

        //
        // POST: /AdServices/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                dichvu.NgayDang = DateTime.Now.Date;
                dichvu.TenKhongDau = func.ConvertToUnSign3(dichvu.TenDichVu);
                dichvu.AnhDaiDien = func.LinkImage(dichvu.AnhDaiDien);
                db.DichVus.Add(dichvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichvu);
        }

        //
        // GET: /AdServices/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /AdServices/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DichVu dichvu)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            if (ModelState.IsValid)
            {
                if (dichvu.TrangThaiXoa)
                {
                    dichvu.NgayXoa = DateTime.Now.Date;
                }
                else
                {
                    dichvu.NgayXoa = null;
                }
                dichvu.TenKhongDau = func.ConvertToUnSign3(dichvu.TenDichVu);
                dichvu.AnhDaiDien = func.LinkImage(dichvu.AnhDaiDien);
                db.Entry(dichvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichvu);
        }

        //
        // GET: /AdServices/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DichVu dichvu = db.DichVus.Find(id);
            if (dichvu == null)
            {
                return HttpNotFound();
            }
            return View(dichvu);
        }

        //
        // POST: /AdServices/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DichVu dichvu = db.DichVus.Find(id);
            db.DichVus.Remove(dichvu);
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