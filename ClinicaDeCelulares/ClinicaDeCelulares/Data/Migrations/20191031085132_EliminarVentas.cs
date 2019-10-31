using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaDeCelulares.Data.Migrations
{
    public partial class EliminarVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vendedor_IdVendedor",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdVendedor",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "IdVendedor",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "VendedorIdVendedor",
                table: "Ventas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorIdVendedor",
                table: "Ventas",
                column: "VendedorIdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vendedor_VendedorIdVendedor",
                table: "Ventas",
                column: "VendedorIdVendedor",
                principalTable: "Vendedor",
                principalColumn: "IdVendedor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vendedor_VendedorIdVendedor",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_VendedorIdVendedor",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "VendedorIdVendedor",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "IdVendedor",
                table: "Ventas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdVendedor",
                table: "Ventas",
                column: "IdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vendedor_IdVendedor",
                table: "Ventas",
                column: "IdVendedor",
                principalTable: "Vendedor",
                principalColumn: "IdVendedor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
