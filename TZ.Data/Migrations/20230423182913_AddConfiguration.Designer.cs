﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TZ.Data;

#nullable disable

namespace TZ.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230423182913_AddConfiguration")]
    partial class AddConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TZ.Domain.DbModels.Experiment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experiments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"),
                            Name = "price"
                        },
                        new
                        {
                            Id = new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"),
                            Name = "button_color"
                        });
                });

            modelBuilder.Entity("TZ.Domain.DbModels.ExperimentResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeviceToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExperimentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentId");

                    b.ToTable("ExperimentResults");
                });

            modelBuilder.Entity("TZ.Domain.DbModels.ExperimentResult", b =>
                {
                    b.HasOne("TZ.Domain.DbModels.Experiment", "Experiment")
                        .WithMany()
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experiment");
                });
#pragma warning restore 612, 618
        }
    }
}
