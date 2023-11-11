using Microsoft.EntityFrameworkCore.Migrations;

namespace RestTomas.Migrations
{
    public partial class adduserid_to_center : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Centers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Centers_UserId",
                table: "Centers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_AspNetUsers_UserId",
                table: "Centers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_AspNetUsers_UserId",
                table: "Centers");

            migrationBuilder.DropIndex(
                name: "IX_Centers_UserId",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Centers");
        }
    }
}
