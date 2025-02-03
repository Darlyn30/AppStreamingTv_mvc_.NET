using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITLATV_.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPathImgProducer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkVideo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Drama" },
                    { 3, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "ImgPath", "Name" },
                values: new object[,]
                {
                    { 1, "https://i.blogs.es/4285e7/netflix-portada/500_333.jpeg", "Netflix" },
                    { 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0CJ1Hes6NEmEew2gvgVtFZ02yCEPpDtKLKw&s", "HBO" },
                    { 3, "https://m.media-amazon.com/images/I/31W9hs7w0JL.png", "Amazon Prime" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "GenderId", "LinkVideo", "Name", "ProducerId", "ReleaseDate", "imgPath" },
                values: new object[,]
                {
                    { 1, "Una persecución sin límites", 1, "https://www.youtube.com/watch?v=kvU4uf8bI0o", "Mad Max: Fury Road", 2, new DateOnly(2022, 6, 15), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPnd7rHMzB99xyxJM_I0qMx4CfBbU3X5lWZw&s" },
                    { 2, "El destino de un asesino", 1, "https://www.youtube.com/watch?v=NbUt7Apl_Z0", "John Wick: Chapter 3", 2, new DateOnly(2021, 7, 20), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnw3TERg5WgeeQfPkEOKfvUa9ozkQnK9Kwpg&s" },
                    { 3, "Venganza y justicia", 1, "https://www.youtube.com/watch?v=VjctHUEmutw", "The Equalizer", 2, new DateOnly(2020, 12, 5), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSBDDqyVkCGitgwrNGC0-4ncraXHB8AkICCAA&s" },
                    { 4, "El renacimiento de un héroe", 1, "https://www.youtube.com/watch?v=NLOp_6uPccQ", "The Batman", 2, new DateOnly(2023, 9, 10), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcS_VtG0teuMR4fRh3lHKASF5DgRYFJJ12xg&s" },
                    { 5, "Espías en acción", 1, "https://www.youtube.com/watch?v=BIhNsAtPbPI", "James Bond: No Time to Die", 2, new DateOnly(2019, 5, 22), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQw33BwddJK9hCCB4fLXYzeMQAIOVbLeKZoww&s" },
                    { 6, "Una comedia que desafía todo", 3, "https://www.youtube.com/watch?v=tcdUhdOlz9M", "The Hangover", 1, new DateOnly(2018, 3, 12), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSzsuhJw9R3Em4QlevtLHubwh8rbWE-LRsIw&s" },
                    { 7, "Dos amigos en un problema absurdo", 3, "https://www.youtube.com/watch?v=l13yPhimE3o", "Dumb and Dumber", 1, new DateOnly(2016, 11, 18), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHmvOC6hQ-HH26kYbCyVlx4rMQNWEehBHZ4g&s" },
                    { 8, "Risas sin parar", 3, "https://www.youtube.com/watch?v=4eaZ_48ZYog", "Superbad", 1, new DateOnly(2020, 8, 30), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR5UxEsOWvisBlyt9VQDUBRWnspIgJVqEEVsg&s" },
                    { 9, "Una historia de superación", 2, "https://www.youtube.com/watch?v=DMOBlEcRuw8", "The Pursuit of Happyness", 3, new DateOnly(2015, 9, 25), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsvSnqLSc7EahZH8SovIf69Xh5xcM8sn3dfQ&s" },
                    { 10, "El peso de la justicia", 2, "https://www.youtube.com/watch?v=Ki4haFrqSrw", "The Green Mile", 3, new DateOnly(2017, 2, 14), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcST-_xVIEU6EaLaetNEvlR8B-aTjuRFnNDhZw&s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_GenderId",
                table: "Series",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ProducerId",
                table: "Series",
                column: "ProducerId");
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
