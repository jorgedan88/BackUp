using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace herramientas_parcial1_OliveraJorgeDaniel.Migrations
{
    /// <inheritdoc />
    public partial class InitianMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiculoNombre = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    VehiculoApellido = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    VehiculoTipo = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    VehiculoMatricula = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    VehiculoFabricacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.VehiculoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
