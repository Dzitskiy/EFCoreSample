﻿// <auto-generated />
using System;
using ConsoleApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConsoleApp2.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID_comp");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.PassInTrip", b =>
                {
                    b.Property<int>("IdPsg")
                        .HasColumnType("integer")
                        .HasColumnName("ID_psg");

                    b.Property<int>("TripNo")
                        .HasColumnType("integer")
                        .HasColumnName("trip_no");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("place");

                    b.HasKey("IdPsg", "TripNo", "Date");

                    b.HasIndex("TripNo");

                    b.ToTable("Pass_in_trip");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID_psg");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Trip", b =>
                {
                    b.Property<int>("TripNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("trip_no");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TripNo"));

                    b.Property<int>("IdComp")
                        .HasColumnType("integer")
                        .HasColumnName("ID_comp");

                    b.Property<string>("Plane")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("plane");

                    b.Property<DateTime>("TimeIn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time_in");

                    b.Property<DateTime>("TimeOut")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time_out");

                    b.Property<string>("TownFrom")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("town_from");

                    b.Property<string>("TownTo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("town_to");

                    b.HasKey("TripNo");

                    b.HasIndex("IdComp");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.PassInTrip", b =>
                {
                    b.HasOne("ConsoleApp2.Entities.Passenger", "Passenger")
                        .WithMany("PassInTrips")
                        .HasForeignKey("IdPsg")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleApp2.Entities.Trip", "Trip")
                        .WithMany("PassInTrips")
                        .HasForeignKey("TripNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Trip", b =>
                {
                    b.HasOne("ConsoleApp2.Entities.Company", "Company")
                        .WithMany("Trips")
                        .HasForeignKey("IdComp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Company", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Passenger", b =>
                {
                    b.Navigation("PassInTrips");
                });

            modelBuilder.Entity("ConsoleApp2.Entities.Trip", b =>
                {
                    b.Navigation("PassInTrips");
                });
#pragma warning restore 612, 618
        }
    }
}
