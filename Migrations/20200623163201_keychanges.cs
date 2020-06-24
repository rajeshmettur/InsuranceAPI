using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAPI.Migrations
{
    public partial class keychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoveragePlan",
                table: "RateCharts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoveragePlan",
                table: "RateCharts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
