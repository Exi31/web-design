using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Models;
using Ex04.StudentManagement.Validators;

namespace Ex04.StudentManagement.Services;

public class StudentService
{
    private readonly List<Student> _students = new();
    private readonly StudentValidator _validator = new();

    public bool Add(Student student, out string message)
    {
        if (_students.Any(s =>
                s.StudentId.Equals(
                    student.StudentId,
                    StringComparison.OrdinalIgnoreCase)))
        {
            message = "Mã sinh viên đã tồn tại. Vui lòng nhập mã khác!";
            return false;
        }

        if (!_validator.IsValid(student, out message))
            return false;

        _students.Add(student);
        message = "Thêm sinh viên thành công!";
        return true;
    }

    public List<Student> GetAll()
    {
        return _students.ToList();
    }

    public Student? GetById(string studentId)
    {
        return _students.FirstOrDefault(s =>
            s.StudentId.Equals(
                studentId.Trim(),
                StringComparison.OrdinalIgnoreCase));
    }

    public bool Exists(string studentId)
    {
        return _students.Any(s =>
            s.StudentId.Equals(
                studentId.Trim(),
                StringComparison.OrdinalIgnoreCase));
    }

    public List<Student> SearchByName(string keyword)
    {
        return _students
            .Where(s => s.FullName.Contains(
                keyword.Trim(),
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public bool Update(Student updatedStudent, out string message)
    {
        Student? existing = GetById(updatedStudent.StudentId);

        if (existing is null)
        {
            message = "Không tìm thấy sinh viên.";
            return false;
        }

        if (!_validator.IsValid(updatedStudent, out message))
            return false;

        existing.Update(
            updatedStudent.FullName,
            updatedStudent.DateOfBirth,
            updatedStudent.Gender,
            updatedStudent.Email,
            updatedStudent.Phone,
            updatedStudent.Major,
            updatedStudent.GPA,
            updatedStudent.Status);

        message = "Cập nhật sinh viên thành công!";
        return true;
    }

    public bool Delete(string studentId, out string message)
    {
        Student? student = GetById(studentId);

        if (student is null)
        {
            message = "Không tìm thấy sinh viên.";
            return false;
        }

        _students.Remove(student);
        message = "Xóa sinh viên thành công!";
        return true;
    }

    public List<Student> SortByName()
    {
        return _students
            .OrderBy(s => s.FullName)
            .ToList();
    }

    public List<Student> SortByGPA()
    {
        return _students
            .OrderByDescending(s => s.GPA)
            .ToList();
    }

    public List<Student> GetStudentsGPAFrom8()
    {
        return _students
            .Where(s => s.GPA >= 8)
            .OrderByDescending(s => s.GPA)
            .ToList();
    }

    public Student? GetTopStudent()
    {
        return _students
            .OrderByDescending(s => s.GPA)
            .FirstOrDefault();
    }

    public List<Student> GetTopStudents()
    {
        if (_students.Count == 0)
            return new List<Student>();

        double maxGpa = _students.Max(s => s.GPA);

        return _students
            .Where(s => s.GPA == maxGpa)
            .ToList();
    }

    public double? GetAverageGPA()
    {
        if (_students.Count == 0)
            return null;

        return _students.Average(s => s.GPA);
    }

    public List<(string Major, int Count)> StatisticsByMajor()
    {
        return _students
            .GroupBy(s => s.Major)
            .Select(g => (Major: g.Key, Count: g.Count()))
            .OrderBy(x => x.Major)
            .ToList();
    }

    public List<(StudentStatus Status, int Count)> StatisticsByStatus()
    {
        return _students
            .GroupBy(s => s.Status)
            .Select(g => (Status: g.Key, Count: g.Count()))
            .OrderBy(x => x.Status)
            .ToList();
    }

    public void SeedSampleData()
    {
        if (_students.Count > 0)
            return;

        var sampleStudents = new[]
        {
            new Student(
                "SV001", "Nguyễn Văn An", new DateTime(2005, 5, 12),
                Gender.Male, "an@gmail.com", "0912345678",
                "CNTT", 8.5, StudentStatus.Studying),

            new Student(
                "SV002", "Trần Thị Bình", new DateTime(2005, 8, 20),
                Gender.Female, "binh@gmail.com", "0987654321",
                "CNTT", 7.8, StudentStatus.Studying),

            new Student(
                "SV003", "Lê Văn Cường", new DateTime(2004, 11, 3),
                Gender.Male, "cuong@gmail.com", "0901234567",
                "Kinh doanh", 9.2, StudentStatus.Studying),

            new Student(
                "SV004", "Phạm Thị Dung", new DateTime(2005, 1, 15),
                Gender.Female, "dung@gmail.com", "0971234567",
                "Marketing", 6.9, StudentStatus.Reserved),

            new Student(
                "SV005", "Hoàng Văn Minh", new DateTime(2004, 3, 8),
                Gender.Male, "minh@gmail.com", "0961234567",
                "CNTT", 8.9, StudentStatus.Graduated)
        };

        foreach (Student student in sampleStudents)
        {
            Add(student, out _);
        }
    }
}
