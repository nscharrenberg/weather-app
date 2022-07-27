﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(StationContext))]
    partial class StationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Domain.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("FeelTemperature")
                        .HasColumnType("REAL");

                    b.Property<double>("GroundTemperature")
                        .HasColumnType("REAL");

                    b.Property<double>("RainFallLastDay")
                        .HasColumnType("REAL");

                    b.Property<int>("StationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SunPower")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("WindDirection")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("Measurement");
                });

            modelBuilder.Entity("Domain.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("Domain.Measurement", b =>
                {
                    b.HasOne("Domain.Station", "Station")
                        .WithMany("Measurements")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Domain.Station", b =>
                {
                    b.Navigation("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}
