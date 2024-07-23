﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(apiContext))]
    [Migration("20240723194320_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("api.Models.WeatherLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Summary")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TemperatureC")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<decimal>("TemperatureF")
                        .HasColumnType("decimal(3, 2)");

                    b.HasKey("Id");

                    b.ToTable("WeatherLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
