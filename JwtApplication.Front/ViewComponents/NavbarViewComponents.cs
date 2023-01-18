using Microsoft.AspNetCore.Mvc;

namespace JwtApplication.Front.ViewComponents
{
    public class NavbarViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
