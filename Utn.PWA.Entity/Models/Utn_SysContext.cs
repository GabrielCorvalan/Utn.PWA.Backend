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
        public virtual DbSet<CompanyTutor> CompanyTutor { get; set; }
        public virtual DbSet<Interships> Interships { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<PagesRols> PagesRols { get; set; }
        public virtual DbSet<Rols> Rols { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
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

            modelBuilder.Entity<CompanyTutor>(entity =>
            {
                entity.HasIndex(e => e.Cuil)
                    .HasName("Unique_CompanyT_Cuil")
                    .IsUnique();

                entity.HasIndex(e => e.Dni)
                    .HasName("Unique_CompanyT_Person")
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
                    .WithMany(p => p.CompanyTutor)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__CompanyTu__Compa__5DCAEF64");
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
                    .HasConstraintName("FK__Intership__Compa__628FA481");

                entity.HasOne(d => d.CompanyTutor)
                    .WithMany(p => p.Interships)
                    .HasForeignKey(d => d.CompanyTutorId)
                    .HasConstraintName("FK__Intership__Compa__6383C8BA");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Interships)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Intership__Stude__619B8048");

                entity.HasOne(d => d.UserCancelattion)
                    .WithMany(p => p.IntershipsUserCancelattion)
                    .HasForeignKey(d => d.UserCancelattionId)
                    .HasConstraintName("FK__Intership__UserC__66603565");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.IntershipsUserCreated)
                    .HasForeignKey(d => d.UserCreatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Intership__UserC__6477ECF3");

                entity.HasOne(d => d.UserLasModified)
                    .WithMany(p => p.IntershipsUserLasModified)
                    .HasForeignKey(d => d.UserLasModifiedId)
                    .HasConstraintName("FK__Intership__UserL__656C112C");

                entity.HasOne(d => d.UserRenovation)
                    .WithMany(p => p.IntershipsUserRenovation)
                    .HasForeignKey(d => d.UserRenovationId)
                    .HasConstraintName("FK__Intership__UserR__6754599E");
            });

            modelBuilder.Entity<Pages>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tittle)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PagesRols>(entity =>
            {
                entity.HasKey(e => new { e.PageId, e.RolId });

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.PagesRols)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PagesRols__PageI__412EB0B6");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.PagesRols)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PagesRols__RolId__4222D4EF");
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
                    .HasConstraintName("FK__Students__Career__5165187F");

                entity.HasOne(d => d.TeacherGuide)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeacherGuideId)
                    .HasConstraintName("FK__Students__Teache__52593CB8");
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
                    .HasConstraintName("FK__Users__RolId__3D5E1FD2");
            });
        }
    }
}
