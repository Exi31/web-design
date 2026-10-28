using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTM_TH_Lab01.Models;

public class Learner
{
    public int LearnerID { get; set; }

    [Display(Name = "Họ")]
    [Required(ErrorMessage = "Vui lòng nhập họ.")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Tên")]
    [Required(ErrorMessage = "Vui lòng nhập tên.")]
    public string FirstMidName { get; set; } = string.Empty;

    [Display(Name = "Ngày nhập học")]
    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "Ngành học")]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn ngành học.")]
    public int MajorID { get; set; }

    public virtual Major? Major { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
        = new HashSet<Enrollment>();
}