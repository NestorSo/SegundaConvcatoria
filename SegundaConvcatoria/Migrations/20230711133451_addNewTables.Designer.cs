﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundaConvcatoria.Data;

#nullable disable

namespace SegundaConvcatoria.Migrations
{
    [DbContext(typeof(CineContext))]
    [Migration("20230711133451_addNewTables")]
    partial class addNewTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SegundaConvcatoria.Models.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("SegundaConvcatoria.Models.Pelicula", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPelicula"));

                    b.Property<int>("Clasificacion")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("Duracion")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPelicula");

                    b.HasIndex("IdGenero");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("SegundaConvcatoria.Models.Pelicula", b =>
                {
                    b.HasOne("SegundaConvcatoria.Models.Genero", "Generos")
                        .WithMany()
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}
