using System;
using System.Linq;
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
                return View(list.ToPagedList(pageNum, pageSize));
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
                return View(list.ToPagedList(pageNum, pageSize));
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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                string smtpUserName = "ducnt.ts24@gmail.com";
                string smtpPassword = "11101993";
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 25;

                string emailTo = "anhtrungduc1993@gmail.com"; // Khi có liên hệ sẽ gửi về thư của mình
                string subject = model.Subject;
                string body = string.Format("Bạn vừa nhận được liên hệ từ: <b>{0}</b><br/>Email: {1}<br/>Số điện thoại: </br>{2}<br/>Nội dung: </br>{3}",
                    model.UserName, model.Email, model.Phone, model.Message);

                EmailService service = new EmailService();

                bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                    emailTo, subject, body);

                if (kq) ModelState.AddModelError("", "Cảm ơn bạn đã liên hệ với chúng tôi.");
                else ModelState.AddModelError("", "Gửi tin nhắn thất bại, vui lòng thử lại.");
            }
            return View(model);
        }
        public ActionResult Information()
        {
            return View();
        }
    }
}
