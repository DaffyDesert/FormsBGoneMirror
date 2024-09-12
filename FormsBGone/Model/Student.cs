using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleInitial { get; set; }

    public string LastName { get; set; } = null!;

    public int Grade { get; set; }

    public string ParentEmail { get; set; } = null!;

    public string TeacherEmail { get; set; } = null!;

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();

    public virtual Parent ParentEmailNavigation { get; set; } = null!;

    public virtual Teacher TeacherEmailNavigation { get; set; } = null!;
}
