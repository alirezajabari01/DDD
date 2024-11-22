using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactical.Orders.Query.Migrations.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddPayLoadToOutBox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "Payload",
               table: "OutBoxEventItem",
               type: "text",
               nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Payload",
               table: "OutBoxEventItem");
        }
    }
}
