using Microsoft.AspNetCore.Mvc;

namespace NTM_Lesson04Views.Controllers
{
    public class NTMRazorCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
