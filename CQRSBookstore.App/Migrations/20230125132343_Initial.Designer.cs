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
    [Migration("20230125132343_Initial")]
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
                            Title = "NHibernate Cookboook"
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

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}