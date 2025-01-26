using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Producers_ProducerName",
                table: "Series");

            migrationBuilder.AlterColumn<string>(
                name: "ProducerName",
                table: "Series",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "Series",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Producers_ProducerName",
                table: "Series",
                column: "ProducerName",
                principalTable: "Producers",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Producers_ProducerName",
                table: "Series");

            migrationBuilder.AlterColumn<string>(
                name: "ProducerName",
                table: "Series",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GenderName",
                table: "Series",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Producers_ProducerName",
                table: "Series",
                column: "ProducerName",
                principalTable: "Producers",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
