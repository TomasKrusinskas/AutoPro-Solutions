using Microsoft.EntityFrameworkCore.Migrations;

namespace RestTomas.Migrations
{
    public partial class AddedCenterproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Technicians_CenterId",
                table: "Technicians",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_Centers_CenterId",
                table: "Technicians",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_Centers_CenterId",
                table: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_CenterId",
                table: "Technicians");
        }
    }
}
