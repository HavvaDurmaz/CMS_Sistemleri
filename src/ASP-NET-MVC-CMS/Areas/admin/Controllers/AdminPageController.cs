using App.Data;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class AdminPageController : Controller
    {
        private readonly AppDbContext db;
        public AdminPageController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Page.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Page data)
        {
            try
            {
                db.Page.Add(data);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View();
        }

        [HttpGet, Route("/admin/AdminPage/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.Page.Find(id));
        }

        [HttpPost, Route("/admin/AdminPage/Update/{id}")]
        public IActionResult Update(int id, Page data)
        {
            try
            {
                var b = db.Page.Find(id);
                b.Content = data.Content;
                b.IsActive = data.IsActive;
                b.Title = data.Title;   
                db.Page.Update(b);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View(db.Page.Find(id));
        }

        [HttpGet, Route("/admin/AdminPage/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Page.Remove(db.Page.Find(id));
                db.SaveChanges();
                TempData["Mesaj"] = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "İşlem Başarısız. - " + e.Message;
            }
            return Redirect("/admin/AdminPage");
        }
    }
}