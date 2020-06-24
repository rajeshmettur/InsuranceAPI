using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAPI.Migrations
{
    public partial class initialDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoveragePlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoveragePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RateCharts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoveragePlanId = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    NetPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateCharts_CoveragePlans_CoveragePlanId",
                        column: x => x.CoveragePlanId,
                        principalTable: "CoveragePlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RateCharts_CoveragePlanId",
                table: "RateCharts",
                column: "CoveragePlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateCharts");

            migrationBuilder.DropTable(
                name: "CoveragePlans");
        }
    }
}
