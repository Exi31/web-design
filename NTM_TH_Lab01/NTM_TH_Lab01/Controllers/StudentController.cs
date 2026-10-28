using Microsoft.AspNetCore.Mvc;
using NTM_TH_Lab01.Models;

namespace NTM_TH_Lab01.Controllers;

[Route("Admin/Student")]
public class StudentController : Controller
{
    private static readonly List<Student> listStudents = new()
    {
        new Student { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
            Gender = Gender.Male, IsRegular = true,
            Address = "A1-2018", Email = "nam@g.com" },
        new Student { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
            Gender = Gender.Female, IsRegular = true,
            Address = "A1-2019", Email = "tu@g.com" },
        new Student { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
            Gender = Gender.Male, IsRegular = false,
            Address = "A1-2020", Email = "phong@g.com" },
        new Student { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
            Gender = Gender.Female, IsRegular = false,
            Address = "A1-2021", Email = "mai@g.com" }
    };

    [HttpGet("List")]
    public IActionResult Index()
    {
        return View(listStudents);
    }

    [HttpGet("Add")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("Add")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student s)
    {
        if (!ModelState.IsValid)
            return View(s);

        s.Id = listStudents.Count == 0
            ? 1
            : listStudents.Max(x => x.Id) + 1;
        listStudents.Add(s);
        return RedirectToAction(nameof(Index));
    }
}