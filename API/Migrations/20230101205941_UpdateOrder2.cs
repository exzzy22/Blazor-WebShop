using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adresses_BillingOrderId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ShippingOrderId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingOrderId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BillingOrderId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_BillingOrderId",
                table: "Adresses",
                column: "BillingOrderId",
                unique: true,
                filter: "[BillingOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ShippingOrderId",
                table: "Adresses",
                column: "ShippingOrderId",
                unique: true,
                filter: "[ShippingOrderId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adresses_BillingOrderId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ShippingOrderId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingOrderId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BillingOrderId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Adresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_BillingOrderId",
                table: "Adresses",
                column: "BillingOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ShippingOrderId",
                table: "Adresses",
                column: "ShippingOrderId",
                unique: true);
        }
    }
}
