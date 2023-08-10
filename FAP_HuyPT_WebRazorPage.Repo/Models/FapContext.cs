using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FAP_HuyPT_WebRazorPage.Repo.Models
{
    public partial class FapContext : DbContext
    {
        public FapContext()
        {
        }

        public FapContext(DbContextOptions<FapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendent> Attendents { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentInCourse> StudentInCourses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				//            optionsBuilder.UseSqlServer("Server=ASUS-HUY;Database=Fap;user=sa;password=123456789;TrustServerCertificate=True");
				var builder = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				IConfigurationRoot configuration = builder.Build();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("Fap"));
			}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Attendent");

                entity.Property(e => e.RoomId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Attendent_Student");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.LectureId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SemesterId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SessionId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_Course_Lecture");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_Course_Semester");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Course_Session");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Course_Subject");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.Property(e => e.LectureId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TecherId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SessionId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("FK_Room_Session");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.VacationEnd).HasColumnType("date");

                entity.Property(e => e.VacationStart).HasColumnType("date");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SessionName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .HasColumnName("TeacherID")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<StudentInCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StudentInCourse");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RoomId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_StudentInCourse_Course");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentInCourse_Student");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
