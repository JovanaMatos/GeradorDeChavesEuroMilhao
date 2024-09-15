﻿// <auto-generated />
using System;
using EuroMilhao2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EuroMilhao2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EuroMilhao2.Models.KeysGeradas", b =>
                {
                    b.Property<int>("KeysId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeysId"));

                    b.Property<DateTime>("DataSorteio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KeyNumber1")
                        .HasColumnType("int");

                    b.Property<int?>("KeyNumber2")
                        .HasColumnType("int");

                    b.Property<int?>("KeyNumber3")
                        .HasColumnType("int");

                    b.Property<int?>("KeyNumber4")
                        .HasColumnType("int");

                    b.Property<int?>("KeyNumber5")
                        .HasColumnType("int");

                    b.Property<int?>("KeyStar1")
                        .HasColumnType("int");

                    b.Property<int?>("KeyStar2")
                        .HasColumnType("int");

                    b.HasKey("KeysId");

                    b.ToTable("ChavesGeradas2");
                });
#pragma warning restore 612, 618
        }
    }
}
