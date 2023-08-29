using App.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP_NET_MVC_CMS.Areas.admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly AppDbContext db;
        public LoginController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string sifre)
        {
            var data = db.User.Where(x => x.Email == email && x.Password == sifre).FirstOrDefault();
            if (data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,data.Name)
                };
                var UserIdentity = new ClaimsIdentity(claims, "AdminGirisi");
                var principal = new ClaimsPrincipal(UserIdentity);
                HttpContext.SignInAsync(principal);
                return Redirect("/Admin/adminBlog");
            }
            else
            {
                ViewBag.Mesaj = "Email Adresi Veya Şifre Yanlış";
                return View();
            }
        }
    }
}
