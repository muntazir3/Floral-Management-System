using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Floral_Shop.Models;

public partial class DbfloralshopContext : DbContext
{
    public DbfloralshopContext()
    {
    }
    public DbfloralshopContext(DbContextOptions<DbfloralshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bouquet> Bouquets { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }
    
    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Occasion> Occasions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bouquet>(entity =>
        {
            entity.HasKey(e => e.BouquetId).HasName("PK__Bouquet__DEF2F6FA2BE9B705");

            entity.ToTable("Bouquet");

            entity.Property(e => e.BouquetId).HasColumnName("BouquetID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OccasionId).HasColumnName("OccasionID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Occasion).WithMany(p => p.Bouquets)
                .HasForeignKey(d => d.OccasionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Bouquet__Occasio__412EB0B6");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__51BCD7975EAE5066");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.BouquetId).HasColumnName("BouquetID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Bouquet).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BouquetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Cart__BouquetID__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Cart__UserID__440B1D61");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Message__C87C037C8BA1F81F");

            entity.ToTable("Message");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.OccasionId).HasColumnName("OccasionID");
            entity.Property(e => e.Text).HasMaxLength(500);

            entity.HasOne(d => d.Occasion).WithMany(p => p.Messages)
                .HasForeignKey(d => d.OccasionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Message__Occasio__3E52440B");
        });

        modelBuilder.Entity<Occasion>(entity =>
        {
            entity.HasKey(e => e.OccasionId).HasName("PK__Occasion__374CAE3CADB192B0");

            entity.ToTable("Occasion");

            entity.HasIndex(e => e.Name, "UQ__Occasion__737584F68214E7F3").IsUnique();

            entity.Property(e => e.OccasionId).HasColumnName("OccasionID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF238DDF29");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomMessage).HasMaxLength(500);
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.RecipientAddress).HasMaxLength(255);
            entity.Property(e => e.RecipientName).HasMaxLength(100);
            entity.Property(e => e.RecipientPhone).HasMaxLength(15);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Message).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MessageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Order__MessageID__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Order__UserID__48CFD27E");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PK__OrderDet__9DD74D9D4DF84DAA");

            entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
            entity.Property(e => e.BouquetId).HasColumnName("BouquetID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.Bouquet).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BouquetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderDeta__Bouqu__4D94879B");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__OrderDeta__Order__4CA06362");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A580AD415AD");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Payment__OrderID__5165187F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3A384FE6");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C2141E23").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

