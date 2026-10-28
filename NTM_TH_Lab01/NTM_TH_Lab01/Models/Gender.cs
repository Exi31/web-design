using System.ComponentModel.DataAnnotations;

namespace NTM_TH_Lab01.Models;

public enum Gender
{
    [Display(Name = "Nam")] Male = 0,
    [Display(Name = "Nữ")] Female = 1
}