using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class FormsByParent
{
    public string Email { get; set; } = null!;

    public string ParentFirstName { get; set; } = null!;

    public string ParentMiddleInitial { get; set; } = null!;

    public string ParentLastName { get; set; } = null!;

    public int StudentId { get; set; }

    public string StudentFirstName { get; set; } = null!;

    public string? StudentMiddleInitial { get; set; }

    public string StudentLastName { get; set; } = null!;

    public int Grade { get; set; }

    public int FormId { get; set; }

    public string FormDescription { get; set; } = null!;

    public DateTime? CompletedDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string FormStatus { get; set; } = null!;

    public string? FormFilePath { get; set; }
}
