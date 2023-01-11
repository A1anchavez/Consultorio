using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.SQLServer.Migrations
{
    public partial class usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "cat");
        }
    }
}
