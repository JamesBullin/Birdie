using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BirdieModels
{
    public partial class BirdieContext : DbContext
    {
        public BirdieContext()
        {
        }

        public BirdieContext(DbContextOptions<BirdieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ball> Ball { get; set; }
        public virtual DbSet<BasicColour> BasicColour { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<OfficialColour> OfficialColour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Birdie;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ball>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficialColourId).HasColumnName("OfficialColourID");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Ball)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__Ball__Manufactur__29572725");

                entity.HasOne(d => d.OfficialColour)
                    .WithMany(p => p.Ball)
                    .HasForeignKey(d => d.OfficialColourId)
                    .HasConstraintName("FK__Ball__OfficialCo__2A4B4B5E");
            });

            modelBuilder.Entity<BasicColour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OfficialColour>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BasicColourId).HasColumnName("BasicColourID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BasicColour)
                    .WithMany(p => p.OfficialColour)
                    .HasForeignKey(d => d.BasicColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OfficialC__Basic__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
