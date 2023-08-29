using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Controllers
{
	public class BlogSingleController : Controller
    {
        private readonly AppDbContext db;
        public BlogSingleController(AppDbContext db)
        {
            this.db = db;
        }
        [Route("/BlogDetay/{BlogAdi}/{id}")]
		public IActionResult Index(string BlogAdi, int id)
		{
			return View(db.Post.Find(id));
		}
	}
}
