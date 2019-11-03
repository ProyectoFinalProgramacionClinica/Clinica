using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaDeCelulares.Data.Migrations
{
    public partial class controladores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    IdVendedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreVendedor = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.IdVendedor);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    VendedorIdVendedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Vendedor_VendedorIdVendedor",
                        column: x => x.VendedorIdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "IdVendedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdVenta = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    IdVendedor = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    VentasIdVenta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Vendedor_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "IdVendedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factura_Ventas_VentasIdVenta",
                        column: x => x.VentasIdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdCliente",
                table: "Factura",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdProducto",
                table: "Factura",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdVendedor",
                table: "Factura",
                column: "IdVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_VentasIdVenta",
                table: "Factura",
                column: "VentasIdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorIdVendedor",
                table: "Ventas",
                column: "VendedorIdVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
