﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiGorevler.Data;

#nullable disable

namespace WebApiGorevler.Data.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20240221120354_Iki")]
    partial class Iki
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiGorevler.Data.Araba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<bool>("IkinciElMi")
                        .HasColumnType("bit");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arabalar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fiyat = 50000.0,
                            IkinciElMi = false,
                            Marka = "Toyota"
                        },
                        new
                        {
                            Id = 2,
                            Fiyat = 45000.0,
                            IkinciElMi = true,
                            Marka = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            Fiyat = 60000.0,
                            IkinciElMi = false,
                            Marka = "Honda"
                        });
                });

            modelBuilder.Entity("WebApiGorevler.Data.Otobus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YolcuKapasitesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Otobusler");
                });
#pragma warning restore 612, 618
        }
    }
}
