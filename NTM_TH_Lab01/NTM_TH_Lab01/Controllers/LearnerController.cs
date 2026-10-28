using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTM_TH_Lab01.Data;
using NTM_TH_Lab01.Models;

namespace NTM_TH_Lab01.Controllers;

public class LearnerController : Controller
{
    private readonly SchoolContext db;

    public LearnerController(SchoolContext context) => db = context;

    private void LoadMajors(int? selected = null)
    {
        ViewBag.MajorID = new SelectList(
            db.Majors.OrderBy(x => x.MajorName).ToList(),
            "MajorID", "MajorName", selected);
    }

    private void ValidateMajor(int majorID)
    {
        if (!db.Majors.Any(x => x.MajorID == majorID))
            ModelState.AddModelError("MajorID", "Ngành học không tồn tại.");
    }

    public IActionResult Index()
    {
        var learners = db.Learners.Include(x => x.Major)
            .OrderBy(x => x.LearnerID).ToList();
        return View(learners);
    }

    [HttpGet]
    public IActionResult Create()
    {
        LoadMajors();
        return View(new Learner { EnrollmentDate = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(
        [Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
    {
        ValidateMajor(learner.MajorID);
        if (ModelState.IsValid)
        {
            db.Learners.Add(learner);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        LoadMajors(learner.MajorID);
        return View(learner);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();
        var learner = db.Learners.Find(id.Value);
        if (learner == null) return NotFound();

        LoadMajors(learner.MajorID);
        return View(learner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id,
        [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")]
        Learner learner)
    {
        if (id != learner.LearnerID) return NotFound();
        var existing = db.Learners.Find(id);
        if (existing == null) return NotFound();

        ValidateMajor(learner.MajorID);
        if (ModelState.IsValid)
        {
            existing.FirstMidName = learner.FirstMidName;
            existing.LastName = learner.LastName;
            existing.MajorID = learner.MajorID;
            existing.EnrollmentDate = learner.EnrollmentDate;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        LoadMajors(learner.MajorID);
        return View(learner);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        var learner = db.Learners.Include(x => x.Major)
            .FirstOrDefault(x => x.LearnerID == id.Value);
        if (learner == null) return NotFound();

        if (db.Enrollments.Any(x => x.LearnerID == id.Value))
            return Content("Người học đã đăng ký môn học nên không thể xóa.");

        return View(learner);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var learner = db.Learners.Find(id);
        if (learner == null) return NotFound();

        // Kiểm tra lại ngay tại POST, kể cả khi GET đã kiểm tra.
        if (db.Enrollments.Any(x => x.LearnerID == id))
            return Content("Người học đã đăng ký môn học nên không thể xóa.");

        db.Learners.Remove(learner);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}