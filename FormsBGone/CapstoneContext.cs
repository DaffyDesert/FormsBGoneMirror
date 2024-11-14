using System;
using System.Collections.Generic;
using FormsBGone.Model;
using Microsoft.EntityFrameworkCore;

namespace FormsBGone;

public partial class CapstoneContext : DbContext
{
	public CapstoneContext()
	{
	}

    public CapstoneContext(DbContextOptions<CapstoneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormsByParent> FormsByParents { get; set; }

    public virtual DbSet<FormsByStudent> FormsByStudents { get; set; }

    public virtual DbSet<FormsByTeacher> FormsByTeachers { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Account");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.AccountType)
                .HasMaxLength(10)
                .HasComment("Parent, Teacher, or Admin")
                .HasColumnName("Account_Type");
            entity.Property(e => e.EncryptedPassword)
                .HasMaxLength(50)
                .HasColumnName("Encrypted_Password");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Administrator");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.AdminId).HasColumnName("Admin_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Middle_Initial");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.ToTable("Form");

            entity.Property(e => e.FormId)
                .ValueGeneratedNever()
                .HasColumnName("Form_ID");
            entity.Property(e => e.AssignedStudentId).HasColumnName("Assigned_Student_Id");
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.FilePath)
                .HasMaxLength(200)
                .HasColumnName("File_Path");
            entity.Property(e => e.FormName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Form_Name");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(50)
                .HasColumnName("Short_Description");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.AssignedStudent).WithMany(p => p.Forms)
                .HasForeignKey(d => d.AssignedStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Form_Student");
        });

        modelBuilder.Entity<FormsByParent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FormsByParent");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.FormDescription)
                .HasMaxLength(50)
                .HasColumnName("Form_Description");
            entity.Property(e => e.FormFilePath)
                .HasMaxLength(200)
                .HasColumnName("Form_File_Path");
            entity.Property(e => e.FormId).HasColumnName("Form_ID");
            entity.Property(e => e.FormStatus)
                .HasMaxLength(50)
                .HasColumnName("Form_Status");
            entity.Property(e => e.ParentFirstName)
                .HasMaxLength(50)
                .HasColumnName("Parent_First_Name");
            entity.Property(e => e.ParentLastName)
                .HasMaxLength(50)
                .HasColumnName("Parent_Last_Name");
            entity.Property(e => e.ParentMiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Parent_Middle_Initial");
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(50)
                .HasColumnName("Student_First_Name");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(50)
                .HasColumnName("Student_Last_Name");
            entity.Property(e => e.StudentMiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Student_Middle_Initial");
        });

        modelBuilder.Entity<FormsByStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FormsByStudent");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.FormDescription)
                .HasMaxLength(50)
                .HasColumnName("Form_Description");
            entity.Property(e => e.FormFilePath)
                .HasMaxLength(200)
                .HasColumnName("Form_File_Path");
            entity.Property(e => e.FormId).HasColumnName("Form_ID");
            entity.Property(e => e.FormStatus)
                .HasMaxLength(50)
                .HasColumnName("Form_Status");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Middle_Initial");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
        });

        modelBuilder.Entity<FormsByTeacher>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("FormsByTeacher");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.FormDescription)
                .HasMaxLength(50)
                .HasColumnName("Form_Description");
            entity.Property(e => e.FormFilePath)
                .HasMaxLength(200)
                .HasColumnName("Form_File_Path");
            entity.Property(e => e.FormId).HasColumnName("Form_ID");
            entity.Property(e => e.FormStatus)
                .HasMaxLength(50)
                .HasColumnName("Form_Status");
            entity.Property(e => e.StudentFirstName)
                .HasMaxLength(50)
                .HasColumnName("Student_First_Name");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.StudentLastName)
                .HasMaxLength(50)
                .HasColumnName("Student_Last_Name");
            entity.Property(e => e.StudentMiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Student_Middle_Initial");
            entity.Property(e => e.TeacherFirstName)
                .HasMaxLength(50)
                .HasColumnName("Teacher_First_Name");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");
            entity.Property(e => e.TeacherLastName)
                .HasMaxLength(50)
                .HasColumnName("Teacher_Last_Name");
            entity.Property(e => e.TeacherMiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Teacher_Middle_Initial");
            entity.Property(e => e.TeacherSuperiorEmail)
                .HasMaxLength(50)
                .HasColumnName("Teacher_Superior_Email");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Parent");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Middle_Initial");

            entity.HasMany(d => d.Students).WithMany(p => p.ParentEmails)
                .UsingEntity<Dictionary<string, object>>(
                    "ParentStudent",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ParentStudent_Student"),
                    l => l.HasOne<Parent>().WithMany()
                        .HasForeignKey("ParentEmail")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ParentStudent_Parent"),
                    j =>
                    {
                        j.HasKey("ParentEmail", "StudentId");
                        j.ToTable("ParentStudent");
                        j.IndexerProperty<string>("ParentEmail")
                            .HasMaxLength(50)
                            .HasColumnName("Parent_Email");
                        j.IndexerProperty<int>("StudentId").HasColumnName("Student_Id");
                    });
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("Student_Id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Middle_Initial");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Email);

            entity.ToTable("Teacher");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(50)
                .HasColumnName("Middle_Initial");
            entity.Property(e => e.SuperiorEmail)
                .HasMaxLength(50)
                .HasColumnName("Superior_Email");
            entity.Property(e => e.TeacherId)
                .HasColumnName("Teacher_Id");

            entity.HasOne(d => d.SuperiorEmailNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SuperiorEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Administrator");

            entity.HasMany(d => d.Students).WithMany(p => p.TeacherEmails)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherStudent",
                    r => r.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeacherStudent_Student"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherEmail")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_TeacherStudent_Teacher"),
                    j =>
                    {
                        j.HasKey("TeacherEmail", "StudentId");
                        j.ToTable("TeacherStudent");
                        j.IndexerProperty<string>("TeacherEmail")
                            .HasMaxLength(50)
                            .HasColumnName("Teacher_Email");
                        j.IndexerProperty<int>("StudentId").HasColumnName("Student_Id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
