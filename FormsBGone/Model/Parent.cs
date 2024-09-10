using System;
using System.Collections.Generic;

namespace FormsBGone.NewFolder;

public partial class Parent
{
    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public virtual Account EmailNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
