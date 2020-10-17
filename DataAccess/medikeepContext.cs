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

                entity.Property(e => e.ItemName).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
