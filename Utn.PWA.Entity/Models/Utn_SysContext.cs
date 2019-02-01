using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Utn.PWA.Entity.Models
{
    public partial class Utn_SysContext : DbContext
    {
        public Utn_SysContext()
        {
        }

        public Utn_SysContext(DbContextOptions<Utn_SysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Careers> Careers { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompanyMentor> CompanyMentor { get; set; }
        public virtual DbSet<Interships> Interships { get; set; }
        public virtual DbSet<Rols> Rols { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Utn_Sys;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Careers>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasIndex(e => e.Cuit)
                    .HasName("Unique_Company_Cuit")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyMentor>(entity =>
            {
                entity.HasIndex(e => e.Cuil)
                    .HasName("Unique_CompanyM_Cuil")
                    .IsUnique();

                entity.HasIndex(e => e.Dni)
                    .HasName("Unique_CompanyM_Person")
                    .IsUnique();

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surnames)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyMentor)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__CompanyMe__Compa__5629CD9C");
            });

            modelBuilder.Entity<Interships>(entity =>
            {
                entity.Property(e => e.CancellationDate).HasColumnType("date");

                entity.Property(e => e.CancellationDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CompanySignatory)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LastModified).HasColumnType("date");

                entity.Property(e => e.Observations)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RenovationDate).HasColumnType("date");

                entity.Property(e => e.SalaryWorkAssignment).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WorkAgreement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Interships)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Intership__Compa__5AEE82B9");

                entity.HasOne(d => d.CompanyMentor)
                    .WithMany(p => p.Interships)
                    .HasForeignKey(d => d.CompanyMentorId)
                    .HasConstraintName("FK__Intership__Compa__5BE2A6F2");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Interships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Intership__Stude__59FA5E80");

                entity.HasOne(d => d.UserCancelattionNavigation)
                    .WithMany(p => p.IntershipsUserCancelattionNavigation)
                    .HasForeignKey(d => d.UserCancelattion)
                    .HasConstraintName("FK__Intership__UserC__5EBF139D");

                entity.HasOne(d => d.UserCreatedNavigation)
                    .WithMany(p => p.IntershipsUserCreatedNavigation)
                    .HasForeignKey(d => d.UserCreated)
                    .HasConstraintName("FK__Intership__UserC__5CD6CB2B");

                entity.HasOne(d => d.UserLasModifiedNavigation)
                    .WithMany(p => p.IntershipsUserLasModifiedNavigation)
                    .HasForeignKey(d => d.UserLasModified)
                    .HasConstraintName("FK__Intership__UserL__5DCAEF64");

                entity.HasOne(d => d.UserRenovationNavigation)
                    .WithMany(p => p.IntershipsUserRenovationNavigation)
                    .HasForeignKey(d => d.UserRenovation)
                    .HasConstraintName("FK__Intership__UserR__5FB337D6");
            });

            modelBuilder.Entity<Rols>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasIndex(e => e.Cuil)
                    .HasName("Unique_Student_Cuil")
                    .IsUnique();

                entity.HasIndex(e => e.Dni)
                    .HasName("Unique_Student_Person")
                    .IsUnique();

                entity.HasIndex(e => e.File)
                    .HasName("Unique_Student_File")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surnames)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Career)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CareerId)
                    .HasConstraintName("FK__Students__Career__49C3F6B7");

                entity.HasOne(d => d.TeacherGuide)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeacherGuideId)
                    .HasConstraintName("FK__Students__Teache__4AB81AF0");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasIndex(e => e.Cuil)
                    .HasName("Unique_Teacher_Cuil")
                    .IsUnique();

                entity.HasIndex(e => e.Dni)
                    .HasName("Unique_Teacher_Person")
                    .IsUnique();

                entity.HasIndex(e => e.File)
                    .HasName("Unique_Teacher_File")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surnames)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surnames)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UniversityPosition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Users__RolId__398D8EEE");
            });
        }
    }
}
