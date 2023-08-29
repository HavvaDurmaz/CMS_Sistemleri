using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Controllers
{
	public class BlogController : Controller
    {
        private readonly AppDbContext db;
        public BlogController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
		{
            ViewBag.Kategoriler = db.Category.ToList();

            return View(db.Post.ToList());
        }
        [Route("/Blogs/{Kategori}/{id}")]
        public IActionResult Bloglar(string Kategori, int id)
        {
            ViewBag.Kategoriler = db.Category.ToList();

            return View(db.Post.Where(x => x.CategoryId == id).ToList());
        }
    }
}