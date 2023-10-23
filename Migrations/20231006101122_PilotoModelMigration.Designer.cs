﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Race_Track.Data;

#nullable disable

namespace herramientas_parcial1_OliveraJorgeDaniel.Migrations
{
    [DbContext(typeof(VehiculoContext))]
    [Migration("20231006101122_PilotoModelMigration")]
    partial class PilotoModelMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Race_Track.Models.Piloto", b =>
                {
                    b.Property<int>("PilotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PilotoApellido")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("PilotoDni")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PilotoExpedicion")
                        .HasColumnType("TEXT");

                    b.Property<string>("PilotoNombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("PilotoNumeroLicencia")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PilotoPropietario")
                        .HasColumnType("INTEGER");

                    b.HasKey("PilotoId");

                    b.ToTable("Piloto");
                });

            modelBuilder.Entity("Race_Track.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehiculoApellido")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VehiculoFabricacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehiculoMatricula")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.Property<string>("VehiculoNombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("VehiculoTipo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
