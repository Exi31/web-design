using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Helpers;
using Ex04.StudentManagement.Models;

namespace Ex04.StudentManagement.Views;

public class StudentConsoleView
{
    public void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("========================================================");
        Console.WriteLine("              QUẢN LÝ SINH VIÊN - C#");
        Console.WriteLine("========================================================");
        Console.WriteLine("1.  Thêm sinh viên");
        Console.WriteLine("2.  Hiển thị danh sách");
        Console.WriteLine("3.  Tìm sinh viên theo mã");
        Console.WriteLine("4.  Tìm gần đúng theo họ tên");
        Console.WriteLine("5.  Cập nhật sinh viên");
        Console.WriteLine("6.  Xóa sinh viên");
        Console.WriteLine("7.  Sắp xếp theo họ tên");
        Console.WriteLine("8.  Sắp xếp theo điểm trung bình");
        Console.WriteLine("9.  Hiển thị sinh viên có GPA từ 8 trở lên");
        Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
        Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
        Console.WriteLine("12. Thống kê sinh viên theo ngành");
        Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
        Console.WriteLine("0.  Thoát");
        Console.WriteLine("========================================================");
    }

    public Student ReadStudent(string studentId)
    {
        string fullName = InputHelper.ReadNonEmptyString("Họ tên: ");
        DateTime dateOfBirth = InputHelper.ReadDate("Ngày sinh (dd/MM/yyyy): ");

        Console.WriteLine("Giới tính:");
        Console.WriteLine("1. Nam");
        Console.WriteLine("2. Nữ");
        Console.WriteLine("3. Khác");
        Gender gender = (Gender)InputHelper.ReadInt("Lựa chọn: ", 1, 3);

        string email = InputHelper.ReadEmail("Email: ");
        string phone = InputHelper.ReadPhoneNumber("Số điện thoại: ");
        string major = InputHelper.ReadNonEmptyString("Ngành học: ");
        double gpa = InputHelper.ReadDouble("Điểm trung bình: ", 0, 10);

        Console.WriteLine("Trạng thái học tập:");
        Console.WriteLine("1. Đang học");
        Console.WriteLine("2. Bảo lưu");
        Console.WriteLine("3. Đã tốt nghiệp");
        Console.WriteLine("4. Thôi học");
        StudentStatus status =
            (StudentStatus)InputHelper.ReadInt("Lựa chọn: ", 1, 4);

        return new Student(
            studentId,
            fullName,
            dateOfBirth,
            gender,
            email,
            phone,
            major,
            gpa,
            status);
    }

    public void ShowStudents(IEnumerable<Student> students)
    {
        List<Student> list = students.ToList();

        if (list.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên đang trống.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine(
            "===============================================================================================================");
        Console.WriteLine(
            "{0,-8} {1,-22} {2,-12} {3,-8} {4,-25} {5,-12} {6,-18} {7,-6} {8,-14}",
            "Mã",
            "Họ tên",
            "Ngày sinh",
            "GT",
            "Email",
            "SĐT",
            "Ngành",
            "GPA",
            "Trạng thái");
        Console.WriteLine(
            "===============================================================================================================");

        foreach (Student s in list)
        {
            Console.WriteLine(
                "{0,-8} {1,-22} {2,-12} {3,-8} {4,-25} {5,-12} {6,-18} {7,-6:F2} {8,-14}",
                s.StudentId,
                s.FullName,
                s.DateOfBirth.ToString("dd/MM/yyyy"),
                GetGenderText(s.Gender),
                s.Email,
                s.Phone,
                s.Major,
                s.GPA,
                GetStatusText(s.Status));
        }

        Console.WriteLine(
            "===============================================================================================================");
    }

    public void ShowStudent(Student student)
    {
        ShowStudents(new[] { student });
    }

    public void ShowMajorStatistics(IEnumerable<(string Major, int Count)> statistics)
    {
        List<(string Major, int Count)> list = statistics.ToList();

        if (list.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên đang trống.");
            return;
        }

        Console.WriteLine("=============== THỐNG KÊ THEO NGÀNH ===============");

        foreach (var item in list)
        {
            Console.WriteLine($"{item.Major,-30}: {item.Count} sinh viên");
        }

        Console.WriteLine("=====================================================");
    }

    public void ShowStatusStatistics(
        IEnumerable<(StudentStatus Status, int Count)> statistics)
    {
        List<(StudentStatus Status, int Count)> list = statistics.ToList();

        if (list.Count == 0)
        {
            Console.WriteLine("Danh sách sinh viên đang trống.");
            return;
        }

        Console.WriteLine("============== THỐNG KÊ TRẠNG THÁI ===============");

        foreach (var item in list)
        {
            Console.WriteLine(
                $"{GetStatusText(item.Status),-20}: {item.Count} sinh viên");
        }

        Console.WriteLine("====================================================");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    private static string GetGenderText(Gender gender)
    {
        return gender switch
        {
            Gender.Male => "Nam",
            Gender.Female => "Nữ",
            Gender.Other => "Khác",
            _ => "Không rõ"
        };
    }

    private static string GetStatusText(StudentStatus status)
    {
        return status switch
        {
            StudentStatus.Studying => "Đang học",
            StudentStatus.Reserved => "Bảo lưu",
            StudentStatus.Graduated => "Tốt nghiệp",
            StudentStatus.DroppedOut => "Thôi học",
            _ => "Không rõ"
        };
    }
}
