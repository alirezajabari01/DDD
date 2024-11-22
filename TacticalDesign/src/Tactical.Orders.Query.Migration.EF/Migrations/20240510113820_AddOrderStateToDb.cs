using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactical.Orders.Query.Migrations.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderStateToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Order");
        }
    }
}
