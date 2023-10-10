using Microsoft.EntityFrameworkCore.Migrations;

namespace RestTomas.Migrations
{
    public partial class AddedCenterproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Techninians_CenterId",
                table: "Techninians",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Techninians_Centers_CenterId",
                table: "Techninians",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Techninians_Centers_CenterId",
                table: "Techninians");

            migrationBuilder.DropIndex(
                name: "IX_Techninians_CenterId",
                table: "Techninians");
        }
    }
}
