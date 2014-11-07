using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult ListProductCatagories(string sortOrder, string currentFilter, string searchString, int? trang)
        {
            if (Session["LogedName"] == null)
            {
                return RedirectToAction("Login", "AdminLogin");
            }
            ViewBag.IDSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
     
            if (searchString != null)
            {
                trang = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var loaiSp = from s in db.LoaiSanPhams
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                loaiSp = loaiSp.Where(s => s.TenLoaiSp.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "id_desc":
                    loaiSp = loaiSp.OrderByDescending(s => s.LoaiSpID);
                    break;
                case "Category":
                    loaiSp = loaiSp.OrderBy(s => s.DanhMuc.TenDanhMuc);
                    break;
                case "category_desc":
                    loaiSp = loaiSp.OrderByDescending(s => s.DanhMuc.TenDanhMuc);
                    break;
                case "Name":
                    loaiSp = loaiSp.OrderBy(s => s.TenLoaiSp);
                    break;
                case "name_desc":
                    loaiSp = loaiSp.OrderByDescending(s => s.TenLoaiSp);
                    break;
                default:  // Name ascending 
                    loaiSp = loaiSp.OrderBy(s => s.LoaiSpID);
                    break;
            }
            const int pageSize = 10;
            int pageNum = trang ?? 1;
            return View(loaiSp.ToPagedList(pageNum,pageSize));
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