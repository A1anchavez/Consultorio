using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Sqlite.Migrations
{
    public partial class Sqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDeTelefono = table.Column<string>(type: "TEXT", nullable: true),
                    Apellido = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "doctor");
        }
    }
}
