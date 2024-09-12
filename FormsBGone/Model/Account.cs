using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Account
{
    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string EncryptedPassword { get; set; } = null!;

    /// <summary>
    /// Parent, Teacher, or Admin
    /// </summary>
    public string? AccountType { get; set; }

    public virtual Parent? Parent { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
