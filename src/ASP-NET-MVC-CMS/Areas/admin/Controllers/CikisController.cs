using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class CikisController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/login");
        }
    }
}
