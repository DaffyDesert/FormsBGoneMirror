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

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();

    public virtual ICollection<Parent> ParentEmails { get; set; } = new List<Parent>();

    public virtual ICollection<Teacher> TeacherEmails { get; set; } = new List<Teacher>();
}
