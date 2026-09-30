using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NTM_Lab05.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [
            Display(Name = "Họ và tên"),
            Required(ErrorMessage = "Họ và tên không được để trống"),
            MinLength(6, ErrorMessage = "Họ tên phải có ít nhất 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ tên chỉ được có nhiều nhất 20 ký tự")
        ]
        public string fullName { get; set; }

        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        
        public string email { get; set; }

        [
            Display(Name = "Số điện thoại"),
            Required(ErrorMessage = "Số điện thoại không được để trống"),
            Remote(action: "VerifyPhone", controller: "Account"),
            DataType(DataType.PhoneNumber)
        ]
        public string phone { get; set; }

        [
            Display(Name = "Địa chỉ"),
            Required(ErrorMessage = "Địa chỉ không được để trống"),
            StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")
        ]
        public string address { get; set; }

        [
            Display(Name = "Ảnh đại diện"),
            Required(ErrorMessage = "Avatar không được để trống")
        ]
        public string avatar { get; set; }

        [
            Display(Name = "Ngày sinh"),
            Required(ErrorMessage = "Ngày sinh không được để trống"),
            DataType(DataType.Date)
        ]
        public DateTime birthday { get; set; }

        [
            Display(Name = "Giới tính"),
            Required(ErrorMessage = "Giới tính không được để trống")
        ]
        public string gender { get; set; }

        [
            Display(Name = "Mật khẩu"),
            DataType(DataType.Password),
            Required(ErrorMessage = "Mật khẩu không được để trống"),
            MinLength(8, ErrorMessage = "Mật khẩu tối thiểu phải có 8 ký tự")
        ]
        public string password { get; set; }

        [
            Display(Name = "Địa chỉ Facebook cá nhân"),
            Required(ErrorMessage = "Facebook không được để trống"),
            Url(ErrorMessage = "URL phải đúng định dạng bao gồm http hoặc https")
        ]
        public string facebook { get; set; }
    }
}
