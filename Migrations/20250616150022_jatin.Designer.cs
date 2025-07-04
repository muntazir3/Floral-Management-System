﻿// <auto-generated />
using System;
using Floral_Shop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Floral_Shop.Migrations
{
    [DbContext(typeof(DbfloralshopContext))]
    [Migration("20250616150022_jatin")]
    partial class jatin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Floral_Shop.Models.Bouquet", b =>
                {
                    b.Property<int>("BouquetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BouquetID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BouquetId"));

                    b.Property<string>("Image")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("OccasionId")
                        .HasColumnType("int")
                        .HasColumnName("OccasionID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("BouquetId")
                        .HasName("PK__Bouquet__DEF2F6FA2BE9B705");

                    b.HasIndex("OccasionId");

                    b.ToTable("Bouquet", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CartID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int?>("BouquetId")
                        .HasColumnType("int")
                        .HasColumnName("BouquetID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("CartId")
                        .HasName("PK__Cart__51BCD7975EAE5066");

                    b.HasIndex("BouquetId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MessageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<int?>("OccasionId")
                        .HasColumnType("int")
                        .HasColumnName("OccasionID");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MessageId")
                        .HasName("PK__Message__C87C037C8BA1F81F");

                    b.HasIndex("OccasionId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.Occasion", b =>
                {
                    b.Property<int>("OccasionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OccasionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OccasionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OccasionId")
                        .HasName("PK__Occasion__374CAE3CADB192B0");

                    b.HasIndex(new[] { "Name" }, "UQ__Occasion__737584F68214E7F3")
                        .IsUnique();

                    b.ToTable("Occasion", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomMessage")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int")
                        .HasColumnName("MessageID");

                    b.Property<string>("RecipientAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RecipientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RecipientPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("OrderId")
                        .HasName("PK__Order__C3905BAF238DDF29");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<int?>("BouquetId")
                        .HasColumnType("int")
                        .HasColumnName("BouquetID");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId")
                        .HasName("PK__OrderDet__9DD74D9D4DF84DAA");

                    b.HasIndex("BouquetId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Floral_Shop.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId")
                        .HasName("PK__Payment__9B556A580AD415AD");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Floral_Shop.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC3A384FE6");

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D10534C2141E23")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Floral_Shop.Models.Bouquet", b =>
                {
                    b.HasOne("Floral_Shop.Models.Occasion", "Occasion")
                        .WithMany("Bouquets")
                        .HasForeignKey("OccasionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Bouquet__Occasio__412EB0B6");

                    b.Navigation("Occasion");
                });

            modelBuilder.Entity("Floral_Shop.Models.Cart", b =>
                {
                    b.HasOne("Floral_Shop.Models.Bouquet", "Bouquet")
                        .WithMany("Carts")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Cart__BouquetID__44FF419A");

                    b.HasOne("Floral_Shop.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Cart__UserID__440B1D61");

                    b.Navigation("Bouquet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Floral_Shop.Models.Message", b =>
                {
                    b.HasOne("Floral_Shop.Models.Occasion", "Occasion")
                        .WithMany("Messages")
                        .HasForeignKey("OccasionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Message__Occasio__3E52440B");

                    b.Navigation("Occasion");
                });

            modelBuilder.Entity("Floral_Shop.Models.Order", b =>
                {
                    b.HasOne("Floral_Shop.Models.Message", "Message")
                        .WithMany("Orders")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK__Order__MessageID__49C3F6B7");

                    b.HasOne("Floral_Shop.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Order__UserID__48CFD27E");

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Floral_Shop.Models.OrderDetail", b =>
                {
                    b.HasOne("Floral_Shop.Models.Bouquet", "Bouquet")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__OrderDeta__Bouqu__4D94879B");

                    b.HasOne("Floral_Shop.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__OrderDeta__Order__4CA06362");

                    b.Navigation("Bouquet");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Floral_Shop.Models.Payment", b =>
                {
                    b.HasOne("Floral_Shop.Models.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Payment__OrderID__5165187F");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Floral_Shop.Models.Bouquet", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Floral_Shop.Models.Message", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Floral_Shop.Models.Occasion", b =>
                {
                    b.Navigation("Bouquets");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Floral_Shop.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Floral_Shop.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
