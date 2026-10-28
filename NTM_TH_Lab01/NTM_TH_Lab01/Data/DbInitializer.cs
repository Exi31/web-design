using System;
using System.Linq;
using NTM_TH_Lab01.Models;

namespace NTM_TH_Lab01.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolContext db)
    {
        db.Database.EnsureCreated();
        if (db.Majors.Any()) return;

        using var transaction = db.Database.BeginTransaction();

        var it = new Major { MajorName = "IT" };
        var economics = new Major { MajorName = "Economics" };
        var mathematics = new Major { MajorName = "Mathematics" };
        db.Majors.AddRange(it, economics, mathematics);

        var carson = new Learner
        {
            FirstMidName = "Carson",
            LastName = "Alexander",
            EnrollmentDate = new DateTime(2005, 9, 1),
            Major = it
        };
        var meredith = new Learner
        {
            FirstMidName = "Meredith",
            LastName = "Alonso",
            EnrollmentDate = new DateTime(2002, 9, 1),
            Major = economics
        };
        db.Learners.AddRange(carson, meredith);

        var chemistry = new Course
        { CourseID = 1050, Title = "Chemistry", Credits = 3 };
        var micro = new Course
        { CourseID = 4022, Title = "Microeconomics", Credits = 3 };
        var macro = new Course
        { CourseID = 4041, Title = "Macroeconomics", Credits = 3 };
        db.Courses.AddRange(chemistry, micro, macro);

        db.Enrollments.AddRange(
            new Enrollment { Learner = carson, Course = chemistry, Grade = 5.5f },
            new Enrollment { Learner = carson, Course = micro, Grade = 7.5f },
            new Enrollment { Learner = meredith, Course = chemistry, Grade = 3.5f },
            new Enrollment { Learner = meredith, Course = macro, Grade = 7f }
        );

        db.SaveChanges();
        transaction.Commit();
    }
}