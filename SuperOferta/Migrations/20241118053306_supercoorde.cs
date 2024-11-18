using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperOferta.Migrations
{
    /// <inheritdoc />
    public partial class supercoorde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coordenadax",
                table: "Supermercados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordenaday",
                table: "Supermercados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordenadax",
                table: "Supermercados");

            migrationBuilder.DropColumn(
                name: "Coordenaday",
                table: "Supermercados");
        }
    }
}
