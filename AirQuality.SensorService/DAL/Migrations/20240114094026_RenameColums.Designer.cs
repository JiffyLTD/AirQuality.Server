﻿// <auto-generated />
using System;
using AirQuality.SensorService.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirQuality.SensorService.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20240114094026_RenameColums")]
    partial class RenameColums
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirQuality.Core.DAL.Models.Station", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("AirQuality.Core.DAL.Models.StationData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Co")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Humidity")
                        .HasColumnType("integer");

                    b.Property<int>("Pm_1")
                        .HasColumnType("integer");

                    b.Property<int>("Pm_10")
                        .HasColumnType("integer");

                    b.Property<int>("Pm_2_5")
                        .HasColumnType("integer");

                    b.Property<int>("Pressure")
                        .HasColumnType("integer");

                    b.Property<Guid>("StationId")
                        .HasColumnType("uuid");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("StationsData");
                });
#pragma warning restore 612, 618
        }
    }
}
