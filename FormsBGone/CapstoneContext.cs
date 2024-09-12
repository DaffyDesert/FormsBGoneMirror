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

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:capstonebgone.database.windows.net,1433;Initial Catalog=capstone;Persist Security Info=False;User ID=Principal;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(50)
                .HasColumnName("Short_Description");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.AssignedStudent).WithMany(p => p.Forms)
                .HasForeignKey(d => d.AssignedStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Form_Student");
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

            entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Parent)
                .HasForeignKey<Parent>(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Parent_Account");
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
            entity.Property(e => e.ParentEmail)
                .HasMaxLength(50)
                .HasColumnName("Parent_Email");
            entity.Property(e => e.TeacherEmail)
                .HasMaxLength(50)
                .HasColumnName("Teacher_Email");

            entity.HasOne(d => d.ParentEmailNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.ParentEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Parent");

            entity.HasOne(d => d.TeacherEmailNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.TeacherEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Teacher");
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
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

            entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Account");

            entity.HasOne(d => d.SuperiorEmailNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SuperiorEmail)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Administrator");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
