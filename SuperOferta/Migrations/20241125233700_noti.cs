using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperOferta.Migrations
{
    /// <inheritdoc />
    public partial class noti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "validado",
                table: "NotificacionesAdmin",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "validado",
                table: "NotificacionesAdmin");
        }
    }
}
