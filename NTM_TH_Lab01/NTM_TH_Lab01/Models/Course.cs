using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTM_TH_Lab01.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CourseID { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }
        = new HashSet<Enrollment>();
}