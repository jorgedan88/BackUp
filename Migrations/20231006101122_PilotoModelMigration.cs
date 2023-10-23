using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace herramientas_parcial1_OliveraJorgeDaniel.Migrations
{
    /// <inheritdoc />
    public partial class PilotoModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Piloto",
                columns: table => new
                {
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoNombre = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    PilotoApellido = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    PilotoDni = table.Column<int>(type: "INTEGER", nullable: false),
                    PilotoNumeroLicencia = table.Column<int>(type: "INTEGER", nullable: false),
                    PilotoExpedicion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PilotoPropietario = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piloto", x => x.PilotoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piloto");
        }
    }
}
