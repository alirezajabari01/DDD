using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactical.Orders.Query.Migrations.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddCouponAmountToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CouponAmount",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponAmount",
                table: "Order");
        }
    }
}
