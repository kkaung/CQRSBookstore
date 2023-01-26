using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CQRSBookstore.App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    ISBN = table.Column<long>(type: "bigint", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "PublishedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("0550818d-36ad-4a8d-9c3a-a715bf15de76"), "VS Vibe", 1343019320124L, new DateTime(2010, 12, 31, 13, 0, 0, 0, DateTimeKind.Utc), "Visual Studio Tips" },
                    { new Guid("8e0f11f1-be5c-4dbc-8012-c19ce8cbe8e1"), "NHibernate King", 5343012320111L, new DateTime(2022, 8, 9, 14, 0, 0, 0, DateTimeKind.Utc), "NHibernate Cookboook" },
                    { new Guid("9b0896fa-3880-4c2e-bfd6-925c87f22878"), "CQRS Queen", 2345019330124L, new DateTime(2015, 6, 30, 14, 0, 0, 0, DateTimeKind.Utc), "CQRS for Dummies" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
