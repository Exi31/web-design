using System.Text.RegularExpressions;
using Ex04.StudentManagement.Enums;
using Ex04.StudentManagement.Models;

namespace Ex04.StudentManagement.Validators;

public class StudentValidator
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$");

    private static readonly Regex PhoneRegex =
        new(@"^\d{9,11}$");

    public bool IsValid(Student student, out string message)
    {
        if (string.IsNullOrWhiteSpace(student.StudentId))
        {
            message = "Mã sinh viên không được để trống.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(student.FullName))
        {
            message = "Họ tên không được để trống.";
            return false;
        }

        if (student.DateOfBirth > DateTime.Today)
        {
            message = "Ngày sinh không được lớn hơn ngày hiện tại.";
            return false;
        }

        if (!Enum.IsDefined(typeof(Gender), student.Gender))
        {
            message = "Giới tính không hợp lệ.";
            return false;
        }

        if (!EmailRegex.IsMatch(student.Email))
        {
            message = "Email không đúng định dạng.";
            return false;
        }

        if (!PhoneRegex.IsMatch(student.Phone))
        {
            message = "Số điện thoại không hợp lệ.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(student.Major))
        {
            message = "Ngành học không được để trống.";
            return false;
        }

        if (student.GPA < 0 || student.GPA > 10)
        {
            message = "GPA phải nằm trong khoảng từ 0 đến 10.";
            return false;
        }

        if (!Enum.IsDefined(typeof(StudentStatus), student.Status))
        {
            message = "Trạng thái học tập không hợp lệ.";
            return false;
        }

        message = "Dữ liệu hợp lệ.";
        return true;
    }
}
