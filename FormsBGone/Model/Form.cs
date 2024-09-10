using System;
using System.Collections.Generic;

namespace FormsBGone.NewFolder;

public partial class Form
{
    public int FormId { get; set; }

    public string? ShortDescription { get; set; }

    public DateTime? CompletedDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? Status { get; set; }

    public int? AssignedStudentId { get; set; }

    public virtual Student? AssignedStudent { get; set; }
}
