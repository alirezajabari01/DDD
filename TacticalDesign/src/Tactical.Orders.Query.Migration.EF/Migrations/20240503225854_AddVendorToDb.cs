using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactical.Orders.Query.Migrations.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddVendorToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_VendorId",
                table: "Order",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vendor_VendorId",
                table: "Order",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vendor_VendorId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_VendorId",
                table: "Order");
        }
    }
}
