using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceAPI.Migrations
{
    public partial class contracttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateCharts_CoveragePlans_CoveragePlanId",
                table: "RateCharts");

            migrationBuilder.DropIndex(
                name: "IX_RateCharts_CoveragePlanId",
                table: "RateCharts");

            migrationBuilder.AddColumn<string>(
                name: "CoveragePlan",
                table: "RateCharts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerGender = table.Column<string>(nullable: true),
                    CustomerCountry = table.Column<string>(nullable: true),
                    CustomerDateOfBirth = table.Column<DateTime>(nullable: false),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    CoveragePlanId = table.Column<int>(nullable: false),
                    CoveragePlan = table.Column<string>(nullable: true),
                    NetPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropColumn(
                name: "CoveragePlan",
                table: "RateCharts");

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
    }
}
