using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace herramientas_parcial1_OliveraJorgeDaniel.Migrations
{
    /// <inheritdoc />
    public partial class RelationOnetoManylMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "Piloto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Piloto_VehiculoId",
                table: "Piloto",
                column: "VehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piloto_Vehiculo_VehiculoId",
                table: "Piloto",
                column: "VehiculoId",
                principalTable: "Vehiculo",
                principalColumn: "VehiculoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piloto_Vehiculo_VehiculoId",
                table: "Piloto");

            migrationBuilder.DropIndex(
                name: "IX_Piloto_VehiculoId",
                table: "Piloto");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "Piloto");
        }
    }
}
