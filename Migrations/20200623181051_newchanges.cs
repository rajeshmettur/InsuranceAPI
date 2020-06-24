using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAPI.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoveragePlan",
                table: "Contracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CoveragePlanId",
                table: "Contracts",
                column: "CoveragePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_CoveragePlans_CoveragePlanId",
                table: "Contracts",
                column: "CoveragePlanId",
                principalTable: "CoveragePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_CoveragePlans_CoveragePlanId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CoveragePlanId",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "CoveragePlan",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
