
using System.ComponentModel.DataAnnotations;

namespace NTMLesson07.Models
{
    public class NTMMember
    {
        [Display(Name = "Mã thành viên")]
        public int ID { get; set; }

        [Display(Name = "Tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên tài khoản có độ dài trong khoảng 3 đến 20 ký tự")]
        public string username { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu tối thiểu 8 ký tự")]
        public string password { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string fullname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email nhập không đúng định dạng")]
        public string email { get; set; }

        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải có 10 ký tự số, bắt đầu bằng số 0")]
        public string phone { get; set; }
    }
}
