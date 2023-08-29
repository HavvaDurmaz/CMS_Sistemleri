using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_MVC_CMS.ViewComponents
{
	public class NavbarViewComponent : ViewComponent
    {
        private readonly AppDbContext db;
        public NavbarViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
		{
			return View(db.Page.Where(x=> x.IsActive == true).ToList());
		}
	}
}
