using System.ComponentModel.DataAnnotations;

namespace NTM_TH_Lab01.Models;

public enum Branch
{
    [Display(Name = "Công nghệ thông tin")] IT = 0,
    [Display(Name = "Kinh tế")] BE = 1,
    [Display(Name = "Công trình")] CE = 2,
    [Display(Name = "Điện - Điện tử")] EE = 3
}