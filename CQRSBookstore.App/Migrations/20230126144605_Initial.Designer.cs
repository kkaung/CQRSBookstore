﻿// <auto-generated />
using System;
using CQRSBookstore.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CQRSBookstore.App.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230126144605_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CQRSBookstore.App.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("PublishedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b0896fa-3880-4c2e-bfd6-925c87f22878"),
                            Author = "CQRS Queen",
                            ISBN = 2345019330124L,
                            PublishedAt = new DateTime(2015, 6, 30, 14, 0, 0, 0, DateTimeKind.Utc),
                            Title = "CQRS for Dummies"
                        },
                        new
                        {
                            Id = new Guid("0550818d-36ad-4a8d-9c3a-a715bf15de76"),
                            Author = "VS Vibe",
                            ISBN = 1343019320124L,
                            PublishedAt = new DateTime(2010, 12, 31, 13, 0, 0, 0, DateTimeKind.Utc),
                            Title = "Visual Studio Tips"
                        },
                        new
                        {
                            Id = new Guid("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"),
                            Author = "NHibernate King",
                            ISBN = 5343012320111L,
                            PublishedAt = new DateTime(2022, 8, 9, 14, 0, 0, 0, DateTimeKind.Utc),
                            Title = "NHibernate Cookbook"
                        });
                });

            modelBuilder.Entity("CQRSBookstore.App.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f3c8222-e935-4551-b48f-a729c9cb26e6"),
                            Number = 8067,
                            PickupDate = new DateTime(2023, 1, 26, 14, 46, 5, 905, DateTimeKind.Utc).AddTicks(5380),
                            ReservationDate = new DateTime(2023, 1, 26, 14, 46, 5, 905, DateTimeKind.Utc).AddTicks(5380)
                        });
                });

            modelBuilder.Entity("CQRSBookstore.App.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("de80e2a6-3455-4a97-a53f-f915cfa21c74"),
                            Email = "johndoe123@gmail.com",
                            Password = "johndoe",
                            Username = "John Doe"
                        });
                });

            modelBuilder.Entity("CQRSBookstore.App.Models.Reservation", b =>
                {
                    b.HasOne("CQRSBookstore.App.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("CQRSBookstore.App.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}