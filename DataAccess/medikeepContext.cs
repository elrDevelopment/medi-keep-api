using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess
{
    public partial class medikeepContext : DbContext
    {
        public medikeepContext()
        {
        }

        public medikeepContext(DbContextOptions<medikeepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:medi-keeper.database.windows.net,1433;Initial Catalog=medikeep;Persist Security Info=False;User ID=erick;Password=Rooster12!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Item_pk")
                    .IsClustered(false);

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ItemCategory).HasMaxLength(15);

                entity.Property(e => e.ItemDescription).HasMaxLength(1000);

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.LastModifiedOn)
                    .HasColumnName("lastModifiedOn")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
