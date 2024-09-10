using System;
using System.Collections.Generic;

namespace FormsBGone.NewFolder;

public partial class Account
{
    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string EncryptedPassword { get; set; } = null!;

    public virtual Parent? Parent { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
