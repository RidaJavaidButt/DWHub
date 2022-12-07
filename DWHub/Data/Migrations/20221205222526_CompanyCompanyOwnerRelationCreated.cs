using Microsoft.EntityFrameworkCore.Migrations;

namespace DWHub.Data.Migrations
{
    public partial class CompanyCompanyOwnerRelationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyOwnerId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyOwnerId",
                table: "Company",
                column: "CompanyOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_CompanyOwner_CompanyOwnerId",
                table: "Company",
                column: "CompanyOwnerId",
                principalTable: "CompanyOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_CompanyOwner_CompanyOwnerId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CompanyOwnerId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CompanyOwnerId",
                table: "Company");
        }
    }
}
