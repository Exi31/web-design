using Microsoft.AspNetCore.Mvc;

namespace NTM_Lesson04Review.Controllers
{
    public class NTMContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["HoTen"] = "Nguyễn Tuấn Minh";
            ViewBag.age = 20;
            TempData["email"] = "tmiikka.8406@gmail.com";
            return View();
        }
    }
}
