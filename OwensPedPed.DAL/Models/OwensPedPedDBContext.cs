using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OwensPedPed.DAL.Models
{
    public partial class OwensPedPedDBContext : DbContext
    {
        public OwensPedPedDBContext()
        {
        }

        public OwensPedPedDBContext(DbContextOptions<OwensPedPedDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Provence> Provences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=OwensPedPedDB;Username=postgres;Password=Pedmond@63");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProvenceId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_CountryId_fkey");

                entity.HasOne(d => d.Provence)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.ProvenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_ProvenceId_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeContactNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmployeeEmailNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmployeeSurname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_CompanyId_fkey");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_CountryId_fkey");

                entity.HasOne(d => d.Provence)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProvenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_ProvenceId_fkey");
            });

            modelBuilder.Entity<Provence>(entity =>
            {
                entity.ToTable("Provence");

                entity.Property(e => e.ProvenceName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Provences)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Provence_CountryId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
