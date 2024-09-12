using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class Form
{
    public int FormId { get; set; }

    public string ShortDescription { get; set; } = null!;

    public DateTime? CompletedDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string Status { get; set; } = null!;

    public int AssignedStudentId { get; set; }

    public string? FilePath { get; set; }

    public virtual Student AssignedStudent { get; set; } = null!;
}
