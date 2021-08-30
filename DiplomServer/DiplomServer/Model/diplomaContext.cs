using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DiplomServer.Model
{
    public partial class diplomaContext : DbContext
    {
        public diplomaContext()
        {
        }

        public diplomaContext(DbContextOptions<diplomaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LXIBY845;Database=diploma;user=max;password=87654321;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId)
                    .ValueGeneratedNever()
                    .HasColumnName("doctorId");

                entity.Property(e => e.Building)
                    .HasMaxLength(20)
                    .HasColumnName("building");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .HasColumnName("department");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Doctors__userId__4222D4EF");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .HasColumnName("date");

                entity.Property(e => e.Decision)
                    .HasMaxLength(200)
                    .HasColumnName("decision");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.Issue)
                    .HasMaxLength(200)
                    .HasColumnName("issue");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Journals__doctor__4BAC3F29");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Journals__patien__4CA06362");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("patientId");

                entity.Property(e => e.Address)
                    .HasMaxLength(30)
                    .HasColumnName("address");

                entity.Property(e => e.BirthDate)
                    .HasMaxLength(20)
                    .HasColumnName("birthDate");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Patients__userId__44FF419A");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .HasColumnName("date");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(30)
                    .HasColumnName("drugName");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Receipts__patien__4F7CD00D");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(20)
                    .HasColumnName("date");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(60)
                    .HasColumnName("doctorName");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Time)
                    .HasMaxLength(10)
                    .HasColumnName("time");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userId");

                entity.Property(e => e.FullName)
                    .HasMaxLength(60)
                    .HasColumnName("fullName");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
