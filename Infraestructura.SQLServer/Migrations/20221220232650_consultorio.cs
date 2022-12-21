using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.SQLServer.Migrations
{
    public partial class consultorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Doctores");

            migrationBuilder.EnsureSchema(
                name: "cat");

            migrationBuilder.EnsureSchema(
                name: "At");

            migrationBuilder.RenameTable(
                name: "Doctores",
                newName: "Doctores",
                newSchema: "cat");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Clientes",
                newSchema: "cat");

            migrationBuilder.RenameColumn(
                name: "NumeroDeTelefono",
                schema: "cat",
                table: "Doctores",
                newName: "numeroTelefonoDoctor");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "cat",
                table: "Doctores",
                newName: "nombreDoctor");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                schema: "cat",
                table: "Doctores",
                newName: "cedulaDoctor");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                schema: "cat",
                table: "Doctores",
                newName: "apellidoDoctor");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "cat",
                table: "Clientes",
                newName: "nombreCliente");

            migrationBuilder.RenameColumn(
                name: "FechaDeNacimiento",
                schema: "cat",
                table: "Clientes",
                newName: "fechaDeNacimientoCliente");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                schema: "cat",
                table: "Clientes",
                newName: "direccionCliente");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                schema: "cat",
                table: "Clientes",
                newName: "apellidoCliente");

            migrationBuilder.AlterColumn<string>(
                name: "numeroTelefonoDoctor",
                schema: "cat",
                table: "Doctores",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombreDoctor",
                schema: "cat",
                table: "Doctores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cedulaDoctor",
                schema: "cat",
                table: "Doctores",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "apellidoDoctor",
                schema: "cat",
                table: "Doctores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombreCliente",
                schema: "cat",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "direccionCliente",
                schema: "cat",
                table: "Clientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "apellidoCliente",
                schema: "cat",
                table: "Clientes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RegConsultas",
                schema: "At",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    fechaDeConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegConsultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegConsultas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "cat",
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegConsultas_Doctores_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "cat",
                        principalTable: "Doctores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegConsultas_ClienteId",
                schema: "At",
                table: "RegConsultas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RegConsultas_DoctorId",
                schema: "At",
                table: "RegConsultas",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegConsultas",
                schema: "At");

            migrationBuilder.RenameTable(
                name: "Doctores",
                schema: "cat",
                newName: "Doctores");

            migrationBuilder.RenameTable(
                name: "Clientes",
                schema: "cat",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "numeroTelefonoDoctor",
                table: "Doctores",
                newName: "NumeroDeTelefono");

            migrationBuilder.RenameColumn(
                name: "nombreDoctor",
                table: "Doctores",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "cedulaDoctor",
                table: "Doctores",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "apellidoDoctor",
                table: "Doctores",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "nombreCliente",
                table: "Clientes",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "fechaDeNacimientoCliente",
                table: "Clientes",
                newName: "FechaDeNacimiento");

            migrationBuilder.RenameColumn(
                name: "direccionCliente",
                table: "Clientes",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "apellidoCliente",
                table: "Clientes",
                newName: "Apellido");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDeTelefono",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Doctores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
