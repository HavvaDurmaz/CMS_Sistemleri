using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Claims;

namespace ASP_NET_MVC_CMS.Controllers
{

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(string Email, string Sifre)
        {
            if (Email == "admin@admin.com" && Sifre == "123")
            {
                //Giriş yapan kullanıcının tarayıcıda gruplandırarak tutmamızı sağlayan sınıf yapısı Claim dir

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"Havva Durmaz"),
                      new Claim(ClaimTypes.Role,"admin "),
                };

                var Userıdentity = new ClaimsIdentity(claims, "AdminGirisi");
                var principal = new ClaimsPrincipal(Userıdentity);

                HttpContext.SignInAsync(principal);
                return Redirect("/admin/Default");

            }
            else
            {
                ViewBag.Message = "Email adresi veya şifre yanlış";

            }

            return View();
        }

    }
}