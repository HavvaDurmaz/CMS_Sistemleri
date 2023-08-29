using App.Data;
using App.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class AdminBlogController : Controller
    {
        private readonly AppDbContext db;
        public AdminBlogController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Post.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Kategori = db.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Post data, IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                if (imageExtension == ".jpg" || imageExtension == ".jpeg")
                {
                    string imageName = Guid.NewGuid() + imageExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/blog/{imageName}");
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    data.PostImage = imageName;
                    db.Post.Add(data);
                    db.SaveChanges();
                    ViewBag.Mesaj = "İşlem Başarılı";
                }
                else
                {
                    ViewBag.Mesaj = ".jpg veya .jpeg uzantılı resim seçmelisiniz.";
                }
            }
            ViewBag.Kategori = db.Category.ToList();
            return View();
        }

        [HttpGet, Route("/admin/AdminBlog/Update/{id}")]
        public IActionResult Update(int id)
        {
            ViewBag.Kategori = db.Category.ToList();
            return View(db.Post.Find(id));
        }

        [HttpPost, Route("/admin/AdminBlog/Update/{id}")]
        public IActionResult Update(int id, Post data, IFormFile file)
        {
            var bulunan = db.Post.Find(id);
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                if (imageExtension == ".jpg" || imageExtension == ".jpeg" || imageExtension == ".png")
                {
                    string imageName = Guid.NewGuid() + imageExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/blog/{imageName}");
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    bulunan.PostImage = imageName;
                }
                else
                {
                    ViewBag.Mesaj = ".jpg veya .jpeg uzantılı resim seçmelisiniz.";
                }
            }
            bulunan.Content = data.Content;
            bulunan.Title = data.Title;
            db.Post.Update(bulunan);
            db.SaveChanges();
            ViewBag.Mesaj = "İşlem Başarılı";

            ViewBag.Kategori = db.Category.ToList();
            return View(db.Post.Find(id));
        }

        [HttpGet, Route("/admin/AdminBlog/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Post.Remove(db.Post.Find(id));
                db.SaveChanges();
                TempData["Mesaj"] = "İşlem Başarılı";
            }
            catch (Exception e)
            {
                TempData["Mesaj"] = "İşlem Başarısız. - " + e.Message;
            }
            return Redirect("/admin/AdminBlog");
        }

        [HttpGet, Route("/admin/AdminBlog/Yorumlar/{id}")]
        public IActionResult Yorumlar(int id)
        {
            return View(db.PostComment.Where(x => x.PostId == id).ToList());
        }

        [HttpGet, Route("/admin/AdminBlog/YorumUpdate/{id}")]
        public IActionResult YorumUpdate(int id)
        {
            var bulunan = db.PostComment.Find(id);
            bulunan.IsActive = (bulunan.IsActive == true ? false : true);
            db.PostComment.Update(bulunan);
            db.SaveChanges();
            TempData["Mesaj"] = "İşlem Başarılı";
            return Redirect("/admin/AdminBlog/Yorumlar/" + bulunan.PostId + "");
        }
    }
}