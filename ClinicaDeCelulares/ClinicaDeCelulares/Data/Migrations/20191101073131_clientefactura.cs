using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaDeCelulares.Data.Migrations
{
    public partial class clientefactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Clientes_ClientesIdCliente",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClientesIdCliente",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClientesIdCliente",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Factura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdCliente",
                table: "Factura",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Clientes_IdCliente",
                table: "Factura",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Clientes_IdCliente",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_IdCliente",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "ClientesIdCliente",
                table: "Factura",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClientesIdCliente",
                table: "Factura",
                column: "ClientesIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Clientes_ClientesIdCliente",
                table: "Factura",
                column: "ClientesIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
