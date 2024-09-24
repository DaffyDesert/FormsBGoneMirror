using System;
using System.Collections.Generic;

namespace FormsBGone.Model;

public partial class FormsByTeacher
{
    public string Email { get; set; } = null!;

    public int TeacherId { get; set; }

    public string TeacherFirstName { get; set; } = null!;

    public string? TeacherMiddleInitial { get; set; }

    public string TeacherLastName { get; set; } = null!;

    public string TeacherSuperiorEmail { get; set; } = null!;

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
