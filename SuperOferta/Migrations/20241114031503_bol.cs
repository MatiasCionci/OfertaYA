using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperOferta.Migrations
{
    /// <inheritdoc />
    public partial class bol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsPublico",
                table: "Supermercados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsPublico",
                table: "Supermercados",
                type: "bit",
                nullable: true);
        }
    }
}
