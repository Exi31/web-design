using System.Text;
using Ex04.StudentManagement.Managers;
using Ex04.StudentManagement.Services;
using Ex04.StudentManagement.Views;

namespace Ex04.StudentManagement;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        StudentService studentService = new();
        StudentConsoleView view = new();

        // Dữ liệu mẫu để kiểm thử nhanh.
        // Nếu muốn chương trình bắt đầu với danh sách rỗng,
        // hãy comment dòng dưới.
        studentService.SeedSampleData();

        MenuManager menuManager =
            new(studentService, view);

        menuManager.Run();
    }
}
