using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KickoffProject.Models
{
    public partial class AdminProjectContext : DbContext
    {
        public AdminProjectContext()
        {
        }

        public AdminProjectContext(DbContextOptions<AdminProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-TPTK142;Database=Admin Project;User Id =sa; password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Category__D837D05F2782E78D");

                entity.Property(e => e.Cid)
                    .HasColumnName("cid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdetails)
                    .HasColumnName("cdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.HasKey(e => e.Subid)
                    .HasName("PK__SubCateg__B0F1D5B3E17A7B39");

                entity.Property(e => e.Subid)
                    .HasColumnName("subid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gst).HasColumnName("gst");

                entity.Property(e => e.Sdetails)
                    .HasColumnName("sdetails")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subname)
                    .IsRequired()
                    .HasColumnName("subname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__SubCategory__cid__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
