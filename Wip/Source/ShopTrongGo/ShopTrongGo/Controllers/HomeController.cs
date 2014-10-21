using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShopTrongGo.Models;

namespace ShopTrongGo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            var id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderBy(p => p.TenSp);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderBy(p => p.Gia);
                return View(list.OrderByDescending(p => p.Gia).ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form, int? page)
        {
            var dbTapHoa = new WebBanTapHoaEntities();
            const int pageSize = 9;
            int pageNum = page ?? 1;
            Session["Home"] = Convert.ToInt32(form["dropdown"]);
            int id = int.Parse(Session["Home"].ToString());
            if (id == 1)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderBy(p => p.TenSp);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            if (id == 2)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderBy(p => p.Gia);
                return View(list.OrderByDescending(p => p.Gia).ToPagedList(pageNum, pageSize));
            }
            if (id == 3)
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.Gia);
                return View(list.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var list = dbTapHoa.SanPhams.Where(sp => !sp.TrangThaiXoa).OrderByDescending(p => p.NgayCapNhat);
                return View(list.ToPagedList(pageNum, pageSize));
            }
        }
    }
}
