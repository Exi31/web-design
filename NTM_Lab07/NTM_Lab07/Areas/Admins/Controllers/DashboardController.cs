using Microsoft.AspNetCore.Mvc;

namespace NTM_Lab07.Areas.Admins
{
    [Area("Admins")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
