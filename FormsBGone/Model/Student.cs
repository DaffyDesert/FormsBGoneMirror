using System;
using System.Collections.Generic;

namespace FormsBGone.NewFolder;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public int? Grade { get; set; }

    public string? ParentEmail { get; set; }

    public int? TeacherId { get; set; }

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();

    public virtual Parent? ParentEmailNavigation { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
