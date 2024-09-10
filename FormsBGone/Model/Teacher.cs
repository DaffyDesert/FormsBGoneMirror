using System;
using System.Collections.Generic;

namespace FormsBGone.NewFolder;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual Account? EmailNavigation { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
