﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManagementSystem.Infrastructure;

#nullable disable

namespace ProductManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("ProductManagementSystem.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductManagementSystem.Core.Entities.ProductGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ProductManagementSystem.Core.Entities.ProductGroupItem", b =>
                {
                    b.Property<Guid>("ProductGroupId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductGroupId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("GroupItems");
                });

            modelBuilder.Entity("ProductManagementSystem.Core.Entities.ProductGroupItem", b =>
                {
                    b.HasOne("ProductManagementSystem.Core.Entities.ProductGroup", null)
                        .WithMany("GroupItems")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagementSystem.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductManagementSystem.Core.Entities.ProductGroup", b =>
                {
                    b.Navigation("GroupItems");
                });
#pragma warning restore 612, 618
        }
    }
}
