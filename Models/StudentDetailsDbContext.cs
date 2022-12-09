using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models;

public partial class StudentDetailsDbContext : DbContext
{
   

    public StudentDetailsDbContext(DbContextOptions<StudentDetailsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<VstudentDetail> VstudentDetails { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__students__4D11D63C48F9129C");

            entity.ToTable("students");

            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.StudentAdd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("studentAdd");
            entity.Property(e => e.StudentClass)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("studentClass");
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("studentName");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__subjects__ACF9A76023981512");

            entity.ToTable("subjects");

            entity.Property(e => e.SubjectId).HasColumnName("subjectId");
            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.SubjectMax)
                .HasDefaultValueSql("((50))")
                .HasColumnName("subjectMax");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("subjectName");
            entity.Property(e => e.SubjectObt).HasColumnName("subjectObt");

            entity.HasOne(d => d.Student).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__subjects__studen__30F848ED");
        });

        modelBuilder.Entity<VstudentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VStudent_details");

            entity.Property(e => e.StudentAdd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("studentAdd");
            entity.Property(e => e.StudentClass)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("studentClass");
            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("studentName");
            entity.Property(e => e.SubjectMax).HasColumnName("subjectMax");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("subjectName");
            entity.Property(e => e.SubjectObt).HasColumnName("subjectObt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
