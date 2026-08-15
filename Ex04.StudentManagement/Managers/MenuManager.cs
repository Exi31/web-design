using Ex04.StudentManagement.Helpers;
using Ex04.StudentManagement.Models;
using Ex04.StudentManagement.Services;
using Ex04.StudentManagement.Views;

namespace Ex04.StudentManagement.Managers;

public class MenuManager
{
    private readonly StudentService _studentService;
    private readonly StudentConsoleView _view;

    public MenuManager(
        StudentService studentService,
        StudentConsoleView view)
    {
        _studentService = studentService;
        _view = view;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            _view.ShowMenu();

            int choice = InputHelper.ReadInt("Lựa chọn: ", 0, 13);

            Console.Clear();

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    _view.ShowStudents(_studentService.GetAll());
                    break;

                case 3:
                    FindStudentById();
                    break;

                case 4:
                    SearchStudentByName();
                    break;

                case 5:
                    UpdateStudent();
                    break;

                case 6:
                    DeleteStudent();
                    break;

                case 7:
                    _view.ShowStudents(_studentService.SortByName());
                    break;

                case 8:
                    _view.ShowStudents(_studentService.SortByGPA());
                    break;

                case 9:
                    _view.ShowStudents(_studentService.GetStudentsGPAFrom8());
                    break;

                case 10:
                    _view.ShowStudents(_studentService.GetTopStudents());
                    break;

                case 11:
                    ShowAverageGPA();
                    break;

                case 12:
                    _view.ShowMajorStatistics(
                        _studentService.StatisticsByMajor());
                    break;

                case 13:
                    _view.ShowStatusStatistics(
                        _studentService.StatisticsByStatus());
                    break;

                case 0:
                    _view.ShowMessage("Đã thoát chương trình.");
                    return;
            }

            Pause();
        }
    }

    private void AddStudent()
    {
        Console.WriteLine("===== THÊM SINH VIÊN =====");

        string studentId;

        while (true)
        {
            studentId =
                InputHelper.ReadNonEmptyString("Mã sinh viên: ");

            if (!_studentService.Exists(studentId))
                break;

            _view.ShowMessage(
                "Mã sinh viên đã tồn tại. Vui lòng nhập mã khác!");
        }

        Student student = _view.ReadStudent(studentId);

        _studentService.Add(student, out string message);
        _view.ShowMessage(message);
    }

    private void FindStudentById()
    {
        Console.WriteLine("===== TÌM SINH VIÊN THEO MÃ =====");

        string studentId =
            InputHelper.ReadNonEmptyString("Nhập mã sinh viên: ");

        Student? student = _studentService.GetById(studentId);

        if (student is null)
        {
            _view.ShowMessage("Không tìm thấy sinh viên.");
            return;
        }

        _view.ShowStudent(student);
    }

    private void SearchStudentByName()
    {
        Console.WriteLine("===== TÌM GẦN ĐÚNG THEO HỌ TÊN =====");

        string keyword =
            InputHelper.ReadNonEmptyString("Nhập họ tên hoặc một phần họ tên: ");

        _view.ShowStudents(_studentService.SearchByName(keyword));
    }

    private void UpdateStudent()
    {
        Console.WriteLine("===== CẬP NHẬT SINH VIÊN =====");

        string studentId =
            InputHelper.ReadNonEmptyString("Nhập mã sinh viên: ");

        Student? existing = _studentService.GetById(studentId);

        if (existing is null)
        {
            _view.ShowMessage("Không tìm thấy sinh viên.");
            return;
        }

        Console.WriteLine("Thông tin hiện tại:");
        _view.ShowStudent(existing);

        Console.WriteLine();
        Console.WriteLine("Nhập thông tin mới:");
        Student updated = _view.ReadStudent(existing.StudentId);

        _studentService.Update(updated, out string message);
        _view.ShowMessage(message);
    }

    private void DeleteStudent()
    {
        Console.WriteLine("===== XÓA SINH VIÊN =====");

        string studentId =
            InputHelper.ReadNonEmptyString("Nhập mã sinh viên: ");

        Student? student = _studentService.GetById(studentId);

        if (student is null)
        {
            _view.ShowMessage("Không tìm thấy sinh viên.");
            return;
        }

        _view.ShowStudent(student);

        bool confirm = InputHelper.ReadYesNo(
            $"Bạn có chắc chắn muốn xóa sinh viên {student.StudentId}? (Y/N): ");

        if (!confirm)
        {
            _view.ShowMessage("Đã hủy thao tác xóa.");
            return;
        }

        _studentService.Delete(studentId, out string message);
        _view.ShowMessage(message);
    }

    private void ShowAverageGPA()
    {
        double? average = _studentService.GetAverageGPA();

        if (average is null)
        {
            _view.ShowMessage("Danh sách sinh viên đang trống.");
            return;
        }

        _view.ShowMessage(
            $"Điểm trung bình toàn bộ sinh viên: {average.Value:F2}");
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Nhấn phím bất kỳ để quay lại menu...");
        Console.ReadKey();
    }
}
