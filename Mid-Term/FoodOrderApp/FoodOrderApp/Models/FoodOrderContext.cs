using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodOrderApp.Models
{
    public partial class FoodOrderContext : DbContext
    {
        public FoodOrderContext()
        {
        }

        public FoodOrderContext(DbContextOptions<FoodOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__Foods__856DB3CB7F60ED59");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.FoodImage)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.DetailId)
                    .HasName("PK__OrderDet__135C314D07F6335A");

                entity.Property(e => e.DetailId).HasColumnName("DetailID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FoodID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderID");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF03317E3D");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CusAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CusName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.CusPhone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OrderAt).HasColumnType("datetime");
            });
        }
    }
}
