using Microsoft.EntityFrameworkCore.Migrations;

namespace DWHub.Data.Migrations
{
    public partial class watchCompanyRelationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Watch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Watch_CompanyID",
                table: "Watch",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Watch_Company_CompanyID",
                table: "Watch",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watch_Company_CompanyID",
                table: "Watch");

            migrationBuilder.DropIndex(
                name: "IX_Watch_CompanyID",
                table: "Watch");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Watch");
        }
    }
}
