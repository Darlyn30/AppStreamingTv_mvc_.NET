using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingPosters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUPZYoxnwtDUaaVd0DW90jUFpsLUjf5TJ5IA&s");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZfZpCMlu5Rb-B1bslBSeU3CP1Cx6lSTP-7g&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6Wcfh_QRfOZtGpC9J9UtvhU7F39wXfO2KHw&s");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2WLUW0TxN1uVbZs47mS1V_vSXe4UePYyC6A&s");
        }
    }
}
