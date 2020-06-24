using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAPI.Migrations
{
    public partial class relationshipkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RateCharts_CoveragePlanId",
                table: "RateCharts",
                column: "CoveragePlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateCharts_CoveragePlans_CoveragePlanId",
                table: "RateCharts",
                column: "CoveragePlanId",
                principalTable: "CoveragePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateCharts_CoveragePlans_CoveragePlanId",
                table: "RateCharts");

            migrationBuilder.DropIndex(
                name: "IX_RateCharts_CoveragePlanId",
                table: "RateCharts");
        }
    }
}
