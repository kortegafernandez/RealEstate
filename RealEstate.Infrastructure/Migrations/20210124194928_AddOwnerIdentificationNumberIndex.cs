using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Infrastructure.Migrations
{
    public partial class AddOwnerIdentificationNumberIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Owners_IdentificationNumber",
                table: "Owners",
                column: "IdentificationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Owners_IdentificationNumber",
                table: "Owners");
        }
    }
}
