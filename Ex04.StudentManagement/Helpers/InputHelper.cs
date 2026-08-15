using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex04.StudentManagement.Helpers;

public static class InputHelper
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$");

    private static readonly Regex PhoneRegex =
        new(@"^\d{9,11}$");

    public static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();

            Console.WriteLine("Dữ liệu không được để trống.");
        }
    }

    public static string ReadEmail(string prompt)
    {
        while (true)
        {
            string email = ReadNonEmptyString(prompt);

            if (EmailRegex.IsMatch(email))
                return email;

            Console.WriteLine("Email không đúng định dạng.");
        }
    }

    public static string ReadPhoneNumber(string prompt)
    {
        while (true)
        {
            string phone = ReadNonEmptyString(prompt);

            if (PhoneRegex.IsMatch(phone))
                return phone;

            Console.WriteLine("Số điện thoại không hợp lệ. Phải có từ 9 đến 11 chữ số.");
        }
    }

    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value)
                && value >= min
                && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Giá trị không hợp lệ. Vui lòng nhập từ {min} đến {max}.");
        }
    }

    public static double ReadDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            // Cho phép cả dấu chấm và dấu phẩy thập phân.
            if (!string.IsNullOrWhiteSpace(input))
            {
                input = input.Replace(',', '.');

                if (double.TryParse(
                        input,
                        NumberStyles.Float,
                        CultureInfo.InvariantCulture,
                        out double value)
                    && value >= min
                    && value <= max)
                {
                    return value;
                }
            }

            Console.WriteLine($"Giá trị không hợp lệ. Vui lòng nhập từ {min} đến {max}.");
        }
    }

    public static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (DateTime.TryParseExact(
                    input,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime date)
                && date <= DateTime.Today)
            {
                return date;
            }

            Console.WriteLine(
                "Ngày không hợp lệ. Hãy nhập đúng định dạng dd/MM/yyyy và không lớn hơn ngày hiện tại.");
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim().ToUpperInvariant();

            if (input == "Y")
                return true;

            if (input == "N")
                return false;

            Console.WriteLine("Vui lòng nhập Y hoặc N.");
        }
    }
}
