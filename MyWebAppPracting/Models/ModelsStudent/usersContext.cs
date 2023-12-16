using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class usersContext : DbContext
    {
        public usersContext()
        {
        }

        public usersContext(DbContextOptions<usersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CoursesAndstudent> CoursesAndstudents { get; set; } = null!;
        public virtual DbSet<Gen> Gens { get; set; } = null!;
        public virtual DbSet<Studentss> Studentsses { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CoursesAndstudent>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesAndstudents)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursesAn__Cours__12FDD1B2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CoursesAndstudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CoursesAn__Stude__13F1F5EB");
            });

            modelBuilder.Entity<Gen>(entity =>
            {
                entity.ToTable("Gen");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Kind).HasMaxLength(10);
            });

            modelBuilder.Entity<Studentss>(entity =>
            {
                entity.HasQueryFilter(s => s.IsDeleted != 1 && s.IsDeleted!=null);
                entity.ToTable("studentss");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Gen)
                    .WithMany(p => p.Studentsses)
                    .HasForeignKey(d => d.GenId)
                    .HasConstraintName("FK__studentss__GenId__0C50D423");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("teachers");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Profession)
                    .HasMaxLength(20)
                    .HasColumnName("profession");

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .HasColumnName("surname");
            });

            modelBuilder.HasSequence<int>("my_sequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
