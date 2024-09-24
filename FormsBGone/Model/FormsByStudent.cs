using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class FormsByStudent
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleInitial { get; set; }

    public string LastName { get; set; } = null!;

    public int Grade { get; set; }

    public int FormId { get; set; }

    public string FormDescription { get; set; } = null!;

    public DateTime? CompletedDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string FormStatus { get; set; } = null!;

    public string? FormFilePath { get; set; }
}
