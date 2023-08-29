using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Controllers
{
    public class SayfalarController : Controller
    {
        private readonly AppDbContext db;
        public SayfalarController(AppDbContext db)
        {
            this.db = db;
        }
        [Route("Sayfa/{SayfaAdi}/{id}")]
        public IActionResult Index(string SayfaAdi, int id)
        {
            return View(db.Page.Find(id));
        }
    }
}
