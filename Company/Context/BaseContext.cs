using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Company.Models;

namespace Company.Context
{
    public partial class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationObjectName> ApplicationObjectName { get; set; }
        public virtual DbSet<ApplicationObjectType> ApplicationObjectType { get; set; }
        public virtual DbSet<BusinessUnits> BusinessUnits { get; set; }
        public virtual DbSet<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CompanyDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationObjectName>(entity =>
            {
                entity.Property(e => e.ApplicationObjectName1).IsUnicode(false);

                entity.HasOne(d => d.ApplicationObjectType)
                    .WithMany(p => p.ApplicationObjectName)
                    .HasForeignKey(d => d.ApplicationObjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationObjectName_ApplicationObjectType");
            });

            modelBuilder.Entity<ApplicationObjectType>(entity =>
            {
                entity.Property(e => e.ApplicationObjectTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<BusinessUnits>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId)
                    .HasName("PK_BusinessUnit");

                entity.Property(e => e.BusinessUnitName).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeLeaves>(entity =>
            {
                entity.Property(e => e.EmployeeLeaveId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeLeaves_Employees");
            });

            modelBuilder.Entity<EmployeeProjects>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeProjects_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeProjects_Projects");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Employee");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmployeeName).IsUnicode(false);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_BusinessUnit");

                entity.HasOne(d => d.EmployeeTypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_ApplicationObjectName");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.ProjectName).IsUnicode(false);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_BusinessUnit");

                entity.HasOne(d => d.ProjectManager)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Employees");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_ApplicationObjectName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
