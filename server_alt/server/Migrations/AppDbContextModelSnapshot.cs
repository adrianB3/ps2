﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Contexts;

namespace server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("server.Models.Data", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("0dab65ce-3c80-4ff1-93cc-36755b2c16b0"));

                    b.Property<bool>("Pump1State");

                    b.Property<bool>("Pump2State");

                    b.Property<bool>("Pump3State");

                    b.Property<bool>("Pump4State");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<bool>("WaterLevelSensor1State");

                    b.Property<bool>("WaterLevelSensor2State");

                    b.Property<bool>("WaterLevelSensor3State");

                    b.Property<bool>("WaterLevelSensor4State");

                    b.HasKey("Id");

                    b.ToTable("Data");

                    b.HasData(
                        new
                        {
                            Id = new Guid("155682a1-8f0d-4cf6-a3bd-7f1a16870eac"),
                            Pump1State = true,
                            Pump2State = true,
                            Pump3State = false,
                            Pump4State = false,
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WaterLevelSensor1State = true,
                            WaterLevelSensor2State = true,
                            WaterLevelSensor3State = true,
                            WaterLevelSensor4State = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
