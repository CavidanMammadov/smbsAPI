using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class teacherAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherCertificate",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrainingTeacher",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AdviceTitle",
                columns: table => new
                {
                    AdviceTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceTitleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdviceTitleAdviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdviceTitle", x => x.AdviceTitleId);
                    table.ForeignKey(
                        name: "FK_AdviceTitle_Advices_AdviceTitleAdviceId",
                        column: x => x.AdviceTitleAdviceId,
                        principalTable: "Advices",
                        principalColumn: "AdviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdviceSubtitle",
                columns: table => new
                {
                    AdviceSubtitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceSubtitleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdviceSubtitleAdviceTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdviceSubtitle", x => x.AdviceSubtitleId);
                    table.ForeignKey(
                        name: "FK_AdviceSubtitle_AdviceTitle_AdviceSubtitleAdviceTitleId",
                        column: x => x.AdviceSubtitleAdviceTitleId,
                        principalTable: "AdviceTitle",
                        principalColumn: "AdviceTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdviceSubtitle_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitle",
                column: "AdviceSubtitleAdviceTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_AdviceTitle_AdviceTitleAdviceId",
                table: "AdviceTitle",
                column: "AdviceTitleAdviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdviceSubtitle");

            migrationBuilder.DropTable(
                name: "AdviceTitle");

            migrationBuilder.DropColumn(
                name: "TeacherCertificate",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingTeacher",
                table: "Trainings");
        }
    }
}
