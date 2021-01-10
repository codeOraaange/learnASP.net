using Microsoft.EntityFrameworkCore.Migrations;

namespace sportstore.Migrations
{
    public partial class pict2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Product",
                type: "text",
                nullable: true);
        }
    }
}
