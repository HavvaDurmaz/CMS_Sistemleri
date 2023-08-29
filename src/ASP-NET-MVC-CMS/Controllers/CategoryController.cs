using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
