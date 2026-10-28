using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTM_TH_Lab01.Models;

public class Major
{
    public int MajorID { get; set; }

    [Required]
    [Display(Name = "Ngành học")]
    public string MajorName { get; set; } = string.Empty;

    public virtual ICollection<Learner> Learners { get; set; }
        = new HashSet<Learner>();
}
