using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ScheduleWebApp
{
    public partial class dfkg9ojh16b4rdContext : DbContext
    {
        public dfkg9ojh16b4rdContext()
        {
        }

        public dfkg9ojh16b4rdContext(DbContextOptions<dfkg9ojh16b4rdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSubject> UserSubjects { get; set; }
        public DbSet<FacultyGroup> FacultyGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ec2-34-253-148-186.eu-west-1.compute.amazonaws.com;Port=5432;Port=5432;Username =txhfeaeowkmudw;Password=991081b5cc1b5a824880f029a9c44c0351a6406425e381c8013c501beca8c1a4;Database=dfkg9ojh16b4rd;SSL Mode=Require;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("faculties");

                entity.HasIndex(e => e.Name, "faculties_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.HasIndex(e => e.Group1, "groups_groups_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacultyId).HasColumnName("facultyId");

                entity.Property(e => e.Group1)
                    .HasColumnType("character varying")
                    .HasColumnName("group");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("groups_facultyId_fkey");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("requests");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RequestText)
                    .HasColumnType("character varying")
                    .HasColumnName("requestText");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("requests_userId_fkey");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.HasIndex(e => e.Day, "schedule_day_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Audience)
                    .HasColumnType("character varying")
                    .HasColumnName("audience");

                entity.Property(e => e.Day)
                    .HasColumnType("character varying")
                    .HasColumnName("day");

                entity.Property(e => e.GroupId).HasColumnName("groupId");

                entity.Property(e => e.Semestr).HasColumnName("semestr");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.Property(e => e.UserSubjectId).HasColumnName("userSubjectId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("schedule_groupId_fkey");

                entity.HasOne(d => d.UserSubject)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.UserSubjectId)
                    .HasConstraintName("schedule_userSubjectId_fkey");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Position)
                    .HasColumnType("character varying")
                    .HasColumnName("position");

                entity.Property(e => e.Salt)
                    .HasColumnType("character varying")
                    .HasColumnName("salt");

                entity.Property(e => e.Surname)
                    .HasColumnType("character varying")
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<UserSubject>(entity =>
            {
                entity.ToTable("userSubjects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.UserSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("userSubjects_subjectId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubjects)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("userSubjects_userId_fkey");
            });
            modelBuilder.Entity<FacultyGroup>().HasNoKey();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
