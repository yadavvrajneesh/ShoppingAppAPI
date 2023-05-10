﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingAppDAL.Context;

#nullable disable

namespace ShoppingAppDAL.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230420095957_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingAppDAL.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("AddressAreaName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("AreaOrColony Name");

                    b.Property<string>("AddressBuildingName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Building Name");

                    b.Property<int>("AddressHouseNumber")
                        .HasColumnType("int")
                        .HasColumnName("House Number");

                    b.Property<string>("AddressType")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Type");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<int>("Pincode")
                        .HasColumnType("int")
                        .HasColumnName("Pincode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("State");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<float>("CartPrice")
                        .HasColumnType("real")
                        .HasColumnName("Price");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.CartProducts", b =>
                {
                    b.Property<int>("CartProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartProductId"));

                    b.Property<int>("CartCount")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartProductId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart Products");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("BillingAddressId")
                        .HasColumnType("int")
                        .HasColumnName("BillingAddressId");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("OrderDate");

                    b.Property<float>("OrderPrice")
                        .HasColumnType("real");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Mode");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int")
                        .HasColumnName("ShippingAddressId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<float>("ProductPrice")
                        .HasColumnType("real")
                        .HasColumnName("Price");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Shopping.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("float")
                        .HasColumnName("Balance");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CardHolderName");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CardNumber");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Mode");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Paid")
                        .HasColumnType("float")
                        .HasColumnName("Paid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Status");

                    b.Property<int>("cvvPin")
                        .HasColumnType("int")
                        .HasColumnName("cvv");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserContact")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Contact");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("Email ID");

                    b.Property<string>("UserFName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("First Name");

                    b.Property<string>("UserLName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Last Name");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Address", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Cart", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.CartProducts", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("ShoppingAppDAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Order", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("ShoppingAppDAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Cart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Product", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingAppDAL.Models.Shopping.Payment", b =>
                {
                    b.HasOne("ShoppingAppDAL.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
