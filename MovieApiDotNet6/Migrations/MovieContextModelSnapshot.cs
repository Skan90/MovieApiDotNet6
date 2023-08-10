﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApiDotNet6.Data;

#nullable disable

namespace MovieApiDotNet6.Migrations;

[DbContext(typeof(MovieContext))]
partial class MovieContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("MovieApiDotNet6.Models.Movie", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Genre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<int>("LengthInMinutes")
                    .HasColumnType("int");

                b.Property<int>("ReleaseYear")
                    .HasColumnType("int");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Movies");
            });
#pragma warning restore 612, 618
    }
}