using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Teacher
{
    public string Email { get; set; } = null!;

    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleInitial { get; set; }

    public string LastName { get; set; } = null!;

    public string SuperiorEmail { get; set; } = null!;

    public virtual Account EmailNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Administrator SuperiorEmailNavigation { get; set; } = null!;
}
