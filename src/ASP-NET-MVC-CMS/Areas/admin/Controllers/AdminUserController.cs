using App.Data;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class AdminUserController : Controller
    {
        private readonly AppDbContext db;
        public AdminUserController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.User.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(User data)
        {
            try
            {
                db.User.Add(data);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View();
        }

        [HttpGet, Route("/admin/AdminUser/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.User.Find(id));
        }

        [HttpPost, Route("/admin/AdminUser/Update/{id}")]
        public IActionResult Update(int id, User data)
        {
            try
            {
                var b = db.User.Find(id);
                b.Name = data.Name;
                b.Password = data.Password;
                b.City = data.City;
                b.Email = data.Email;
                b.Phone = data.Phone;
                db.User.Update(b);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View(db.User.Find(id));
        }

        [HttpGet, Route("/admin/AdminUser/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                db.User.Remove(db.User.Find(id));
                db.SaveChanges();
                TempData["Mesaj"] = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "İşlem Başarısız. - " + e.Message;
            }
            return Redirect("/admin/AdminUser");
        }
    }
}
