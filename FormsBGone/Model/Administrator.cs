using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Administrator
{
    public string Email { get; set; } = null!;

    public int AdminId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleInitial { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
