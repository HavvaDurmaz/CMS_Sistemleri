using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
