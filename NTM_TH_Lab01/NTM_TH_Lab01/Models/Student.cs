using System;
using System.ComponentModel.DataAnnotations;

namespace NTM_TH_Lab01.Models;

public class Student
{
    public int Id { get; set; }
    public string? AvatarUrl { get; set; }

    [Display(Name = "Họ tên")]
    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    [StringLength(100, MinimumLength = 4,
        ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự.")]
    public string? Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Vui lòng nhập email.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [RegularExpression(@"^[A-Za-z0-9._%+\-]+@gmail\.com$",
        ErrorMessage = "Email phải có đuôi @gmail.com.")]
    public string? Email { get; set; }

    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [StringLength(100, MinimumLength = 8,
        ErrorMessage = "Mật khẩu phải từ 8 đến 100 ký tự.")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9\s])\S+$",
        ErrorMessage = "Mật khẩu cần chữ hoa, chữ thường, chữ số, ký tự đặc biệt và không có khoảng trắng.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Ngành học")]
    [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
    public Branch? Branch { get; set; }

    [Display(Name = "Giới tính")]
    [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
    public Gender? Gender { get; set; }

    [Display(Name = "Hệ chính quy")]
    public bool IsRegular { get; set; }

    [Display(Name = "Địa chỉ")]
    [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }

    [Display(Name = "Ngày sinh")]
    [Required(ErrorMessage = "Vui lòng chọn ngày sinh.")]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
        ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005.",
        ParseLimitsInInvariantCulture = true)]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Điểm")]
    [Required(ErrorMessage = "Vui lòng nhập điểm.")]
    [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0 đến 10.")]
    public double? Grade { get; set; }
}