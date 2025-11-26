using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElderlySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class statusEderly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Elderlies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Elderlies");
        }
    }
}
