using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLaunch = table.Column<DateOnly>(type: "date", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProducerName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Genders_GenderName",
                        column: x => x.GenderName,
                        principalTable: "Genders",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Producers_ProducerName",
                        column: x => x.ProducerName,
                        principalTable: "Producers",
                        principalColumn: "Name");
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Name", "Description", "Id" },
                values: new object[,]
                {
                    { "Action", null, 0 },
                    { "Comedy", null, 0 },
                    { "Drama", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Name", "Id" },
                values: new object[,]
                {
                    { "Amazon Prime", 0 },
                    { "HBO", 0 },
                    { "Netflix", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_GenderName",
                table: "Series",
                column: "GenderName");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ProducerName",
                table: "Series",
                column: "ProducerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
