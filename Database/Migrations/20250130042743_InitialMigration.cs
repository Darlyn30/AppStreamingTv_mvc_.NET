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

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "DateLaunch", "Description", "GenderName", "ImagePath", "Name", "ProducerName" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 6, 15), "Una persecución sin límites", "Action", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPnd7rHMzB99xyxJM_I0qMx4CfBbU3X5lWZw&s", "Mad Max: Fury Road", "HBO" },
                    { 2, new DateOnly(2021, 7, 20), "El destino de un asesino", "Action", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnw3TERg5WgeeQfPkEOKfvUa9ozkQnK9Kwpg&s", "John Wick: Chapter 3", "HBO" },
                    { 3, new DateOnly(2020, 12, 5), "Venganza y justicia", "Action", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBDDqyVkCGitgwrNGC0-4ncraXHB8AkICCAA&s", "The Equalizer", "HBO" },
                    { 4, new DateOnly(2023, 9, 10), "El renacimiento de un héroe", "Action", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcS_VtG0teuMR4fRh3lHKASF5DgRYFJJ12xg&s", "The Batman", "HBO" },
                    { 5, new DateOnly(2019, 5, 22), "Espías en acción", "Action", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQw33BwddJK9hCCB4fLXYzeMQAIOVbLeKZoww&s", "James Bond: No Time to Die", "HBO" },
                    { 6, new DateOnly(2018, 3, 12), "Una comedia que desafía todo", "Comedy", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSzsuhJw9R3Em4QlevtLHubwh8rbWE-LRsIw&s", "The Hangover", "Netflix" },
                    { 7, new DateOnly(2016, 11, 18), "Dos amigos en un problema absurdo", "Comedy", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHmvOC6hQ-HH26kYbCyVlx4rMQNWEehBHZ4g&s", "Dumb and Dumber", "Netflix" },
                    { 8, new DateOnly(2020, 8, 30), "Risas sin parar", "Comedy", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5UxEsOWvisBlyt9VQDUBRWnspIgJVqEEVsg&s", "Superbad", "Netflix" },
                    { 9, new DateOnly(2015, 9, 25), "Una historia de superación", "Drama", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsvSnqLSc7EahZH8SovIf69Xh5xcM8sn3dfQ&s", "The Pursuit of Happyness", "Amazon Prime" },
                    { 10, new DateOnly(2017, 2, 14), "El peso de la justicia", "Drama", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST-_xVIEU6EaLaetNEvlR8B-aTjuRFnNDhZw&s", "The Green Mile", "Amazon Prime" },
                    { 11, new DateOnly(2016, 7, 15), "Un grupo de amigos descubre misterios sobrenaturales en su pequeña ciudad.", "Drama", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6Wcfh_QRfOZtGpC9J9UtvhU7F39wXfO2KHw&s", "Stranger Things", "Netflix" },
                    { 12, new DateOnly(2008, 1, 20), "Un profesor de química se convierte en narcotraficante tras ser diagnosticado con cáncer.", "Drama", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2WLUW0TxN1uVbZs47mS1V_vSXe4UePYyC6A&s", "Breaking Bad", "Netflix" }
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
