using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTMLesson07.Models;

namespace NTMLesson07.Controllers
{
    public class NTMMemberController : Controller
    {
        private static List<NTMMember> listMembers = new List<NTMMember>();

        // GET: NTMMemberController
        public ActionResult Index()
        {
            return View(listMembers);
        }

        // GET: NTMMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NTMMemberController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NTMMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NTMMember member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            listMembers.Add(member);
            return RedirectToAction("Index");
        }

        // GET: NTMMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NTMMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NTMMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NTMMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
