using App.Data;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class AdminCategoryController : Controller
    {
        private readonly AppDbContext db;
        public AdminCategoryController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Category.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category data)
        {
            try
            {
                db.Category.Add(data);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View();
        }

        [HttpGet, Route("/admin/AdminCategory/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(db.Category.Find(id));
        }

        [HttpPost, Route("/admin/AdminCategory/Update/{id}")]
        public IActionResult Update(int id, Category data)
        {
            try
            {
                var bulunan = db.Category.Find(id);
                bulunan.Description = data.Description;
                bulunan.Name = data.Name;
                db.Category.Update(bulunan);
                db.SaveChanges();
                ViewBag.Mesaj = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = "İşlem Başarısız. - " + e.Message;
            }
            return View(db.Category.Find(id));
        }

        [HttpGet, Route("/admin/AdminCategory/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Category.Remove(db.Category.Find(id));
                db.SaveChanges();
                TempData["Mesaj"] = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "İşlem Başarısız. - " + e.Message;
            }
            return Redirect("/admin/AdminCategory");
        }
    }
}