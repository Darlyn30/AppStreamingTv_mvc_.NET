using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITLATV_.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingDescriptionPropDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Series",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Series");
        }
    }
}
