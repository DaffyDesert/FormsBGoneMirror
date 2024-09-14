using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Parent
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string MiddleInitial { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
