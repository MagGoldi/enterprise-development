﻿// <auto-generated />
using System;
using BicycleRent.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicycleRent.Domain.Migrations
{
    [DbContext(typeof(BicycleRentDbContext))]
    [Migration("20241217173713_Laba4Migration2")]
    partial class Laba4Migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BicycleRent.Domain.Entities.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("bicycle_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BicycleId"));

                    b.Property<string>("Color")
                        .HasColumnType("longtext")
                        .HasColumnName("color");

                    b.Property<string>("Model")
                        .HasColumnType("longtext")
                        .HasColumnName("model");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("serial_number");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.HasKey("BicycleId");

                    b.HasIndex("TypeId");

                    b.ToTable("bicycles");

                    b.HasData(
                        new
                        {
                            BicycleId = 1,
                            Color = "Blue",
                            Model = "Navigator 910 MD",
                            SerialNumber = "M001",
                            TypeId = 1
                        },
                        new
                        {
                            BicycleId = 2,
                            Color = "Orange",
                            Model = "Forward Apache 29 XD",
                            SerialNumber = "M002",
                            TypeId = 1
                        },
                        new
                        {
                            BicycleId = 3,
                            Color = "Yellow",
                            Model = "Stinger Element Evo 29",
                            SerialNumber = "M003",
                            TypeId = 1
                        },
                        new
                        {
                            BicycleId = 4,
                            Color = "White",
                            Model = "Aspect Allroad",
                            SerialNumber = "R001",
                            TypeId = 2
                        },
                        new
                        {
                            BicycleId = 5,
                            Color = "Black",
                            Model = "Stark Peloton",
                            SerialNumber = "R002",
                            TypeId = 2
                        },
                        new
                        {
                            BicycleId = 6,
                            Color = "Black-Blue",
                            Model = "Format 5211",
                            SerialNumber = "R003",
                            TypeId = 2
                        },
                        new
                        {
                            BicycleId = 7,
                            Color = "Beige",
                            Model = "Stark Comfort 3-speed",
                            SerialNumber = "W001",
                            TypeId = 3
                        },
                        new
                        {
                            BicycleId = 8,
                            Color = "Gray",
                            Model = "Stels Energy VI",
                            SerialNumber = "W002",
                            TypeId = 3
                        },
                        new
                        {
                            BicycleId = 9,
                            Color = "White",
                            Model = "Stark Comfort 3-speed",
                            SerialNumber = "W003",
                            TypeId = 3
                        },
                        new
                        {
                            BicycleId = 10,
                            Color = "Orange",
                            Model = "Format 5222 CF",
                            SerialNumber = "S001",
                            TypeId = 4
                        },
                        new
                        {
                            BicycleId = 11,
                            Color = "Beige",
                            Model = "Bear Bike Perm 2021",
                            SerialNumber = "S002",
                            TypeId = 4
                        },
                        new
                        {
                            BicycleId = 12,
                            Color = "Black",
                            Model = "Electra Loft 7D",
                            SerialNumber = "S003",
                            TypeId = 4
                        });
                });

            modelBuilder.Entity("BicycleRent.Domain.Entities.BicycleRenter", b =>
                {
                    b.Property<int>("RenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("renter_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RenterId"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("id_bicycle");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("full_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.HasKey("RenterId");

                    b.ToTable("bicycle_renters");

                    b.HasData(
                        new
                        {
                            RenterId = 1,
                            BirthDate = new DateOnly(2000, 9, 1),
                            FullName = "Kruglova Daria Grigorievna",
                            PhoneNumber = "71110010101"
                        },
                        new
                        {
                            RenterId = 2,
                            BirthDate = new DateOnly(1978, 1, 27),
                            FullName = "Astakhov Timur Fedorovich",
                            PhoneNumber = "71114668965"
                        },
                        new
                        {
                            RenterId = 3,
                            BirthDate = new DateOnly(1999, 8, 10),
                            FullName = "Morozov Konstantin Alexandrovich",
                            PhoneNumber = "71117382789"
                        },
                        new
                        {
                            RenterId = 4,
                            BirthDate = new DateOnly(2004, 12, 11),
                            FullName = "Timofeev Nikolai Alexandrovich",
                            PhoneNumber = "71110661323"
                        },
                        new
                        {
                            RenterId = 5,
                            BirthDate = new DateOnly(1989, 3, 22),
                            FullName = "Zakharova Kristina Konstantinovna",
                            PhoneNumber = "71111970567"
                        },
                        new
                        {
                            RenterId = 6,
                            BirthDate = new DateOnly(2002, 5, 17),
                            FullName = "Shcherbakov Vladimir Semyonovich",
                            PhoneNumber = "71113754455"
                        },
                        new
                        {
                            RenterId = 7,
                            BirthDate = new DateOnly(1997, 10, 19),
                            FullName = "Stepanova Ekaterina Dmitrievna",
                            PhoneNumber = "71111238745"
                        },
                        new
                        {
                            RenterId = 8,
                            BirthDate = new DateOnly(1998, 6, 8),
                            FullName = "Kuznetsova Alina Igorevna",
                            PhoneNumber = "71113039008"
                        },
                        new
                        {
                            RenterId = 9,
                            BirthDate = new DateOnly(2003, 5, 28),
                            FullName = "Sokolov Daniil Ivanovich",
                            PhoneNumber = "71118567832"
                        },
                        new
                        {
                            RenterId = 10,
                            BirthDate = new DateOnly(2000, 2, 28),
                            FullName = "Makarov Savva Evgenievich",
                            PhoneNumber = "71113840393"
                        });
                });

            modelBuilder.Entity("BicycleRent.Domain.Entities.BicycleType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("type");

                    b.HasKey("TypeId");

                    b.ToTable("bicycle_types");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Price = 300m,
                            Type = "Mountain"
                        },
                        new
                        {
                            TypeId = 2,
                            Price = 200m,
                            Type = "Road"
                        },
                        new
                        {
                            TypeId = 3,
                            Price = 200m,
                            Type = "Walking"
                        },
                        new
                        {
                            TypeId = 4,
                            Price = 250m,
                            Type = "Sport"
                        });
                });

            modelBuilder.Entity("BicycleRent.Domain.Entities.Rent", b =>
                {
                    b.Property<int>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rent_id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RentId"));

                    b.Property<int>("BicycleId")
                        .HasColumnType("int")
                        .HasColumnName("bicycle_id");

                    b.Property<int>("RenterId")
                        .HasColumnType("int")
                        .HasColumnName("renter_id");

                    b.Property<DateTime?>("TimeEnd")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("time_end");

                    b.Property<DateTime?>("TimeStart")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("time_start");

                    b.HasKey("RentId");

                    b.HasIndex("BicycleId");

                    b.HasIndex("RenterId");

                    b.ToTable("rents");

                    b.HasData(
                        new
                        {
                            RentId = 1,
                            BicycleId = 1,
                            RenterId = 1,
                            TimeEnd = new DateTime(2024, 5, 12, 14, 35, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 5, 12, 12, 35, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 2,
                            BicycleId = 2,
                            RenterId = 2,
                            TimeEnd = new DateTime(2024, 6, 1, 20, 50, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 6, 1, 16, 50, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 3,
                            BicycleId = 2,
                            RenterId = 2,
                            TimeEnd = new DateTime(2024, 6, 5, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 6, 5, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 4,
                            BicycleId = 11,
                            RenterId = 2,
                            TimeEnd = new DateTime(2024, 7, 10, 18, 15, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 7, 10, 15, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 5,
                            BicycleId = 12,
                            RenterId = 3,
                            TimeEnd = new DateTime(2024, 9, 10, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 6,
                            BicycleId = 8,
                            RenterId = 4,
                            TimeEnd = new DateTime(2024, 8, 18, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 8, 18, 17, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 7,
                            BicycleId = 9,
                            RenterId = 4,
                            TimeEnd = new DateTime(2024, 7, 1, 20, 20, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 7, 1, 18, 20, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 8,
                            BicycleId = 4,
                            RenterId = 5,
                            TimeEnd = new DateTime(2024, 4, 29, 16, 55, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 4, 29, 13, 55, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 9,
                            BicycleId = 3,
                            RenterId = 6,
                            TimeEnd = new DateTime(2024, 4, 29, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 4, 29, 7, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 10,
                            BicycleId = 8,
                            RenterId = 6,
                            TimeEnd = new DateTime(2024, 7, 7, 20, 35, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 7, 7, 19, 35, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 11,
                            BicycleId = 7,
                            RenterId = 6,
                            TimeEnd = new DateTime(2024, 6, 28, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 6, 28, 14, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 12,
                            BicycleId = 6,
                            RenterId = 6,
                            TimeEnd = new DateTime(2024, 5, 30, 17, 40, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 5, 30, 13, 40, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 13,
                            BicycleId = 3,
                            RenterId = 7,
                            TimeEnd = new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 14,
                            BicycleId = 5,
                            RenterId = 8,
                            TimeEnd = new DateTime(2024, 8, 1, 14, 5, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 8, 1, 12, 5, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 15,
                            BicycleId = 10,
                            RenterId = 8,
                            TimeEnd = new DateTime(2024, 8, 8, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 8, 8, 12, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 16,
                            BicycleId = 7,
                            RenterId = 9,
                            TimeEnd = new DateTime(2024, 9, 1, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 9, 1, 16, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 17,
                            BicycleId = 11,
                            RenterId = 9,
                            TimeEnd = new DateTime(2024, 6, 11, 18, 45, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 6, 11, 17, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 18,
                            BicycleId = 1,
                            RenterId = 9,
                            TimeEnd = new DateTime(2024, 7, 19, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 7, 19, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 19,
                            BicycleId = 12,
                            RenterId = 10,
                            TimeEnd = new DateTime(2024, 6, 11, 18, 45, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 6, 11, 17, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            RentId = 20,
                            BicycleId = 8,
                            RenterId = 10,
                            TimeEnd = new DateTime(2024, 8, 3, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            TimeStart = new DateTime(2024, 8, 3, 16, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BicycleRent.Domain.Entities.Bicycle", b =>
                {
                    b.HasOne("BicycleRent.Domain.Entities.BicycleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BicycleRent.Domain.Entities.Rent", b =>
                {
                    b.HasOne("BicycleRent.Domain.Entities.Bicycle", "Bicycle")
                        .WithMany()
                        .HasForeignKey("BicycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BicycleRent.Domain.Entities.BicycleRenter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bicycle");

                    b.Navigation("Renter");
                });
#pragma warning restore 612, 618
        }
    }
}
