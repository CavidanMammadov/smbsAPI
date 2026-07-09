using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CorporateTrainings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateTrainings",
                columns: table => new
                {
                    CorporateTrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateTrainingCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateTrainingPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateTrainingDirection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateTrainingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateTrainingContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateTrainingEmployeeCount = table.Column<int>(type: "int", nullable: false),
                    CorporateTrainingContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorporateTrainingCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorporateTrainingIsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateTrainings", x => x.CorporateTrainingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateTrainings");
        }
    }
}
