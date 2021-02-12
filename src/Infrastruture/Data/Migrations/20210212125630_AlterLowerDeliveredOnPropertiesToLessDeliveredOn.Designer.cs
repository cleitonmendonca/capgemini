﻿// <auto-generated />
using System;
using Infrastruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastruture.Data.Migrations
{
    [DbContext(typeof(CapgeminiDbContext))]
    [Migration("20210212125630_AlterLowerDeliveredOnPropertiesToLessDeliveredOn")]
    partial class AlterLowerDeliveredOnPropertiesToLessDeliveredOn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Application.Entities.Importation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LessDeliveredDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Importations");
                });

            modelBuilder.Entity("Application.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeliveredOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("ImportationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ImportationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Application.Entities.Product", b =>
                {
                    b.HasOne("Application.Entities.Importation", "Importation")
                        .WithMany("Products")
                        .HasForeignKey("ImportationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Importation");
                });

            modelBuilder.Entity("Application.Entities.Importation", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
