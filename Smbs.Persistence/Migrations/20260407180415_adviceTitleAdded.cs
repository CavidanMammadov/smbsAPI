using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adviceTitleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdviceSubtitle_AdviceTitle_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitle");

            migrationBuilder.DropForeignKey(
                name: "FK_AdviceTitle_Advices_AdviceTitleAdviceId",
                table: "AdviceTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdviceTitle",
                table: "AdviceTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdviceSubtitle",
                table: "AdviceSubtitle");

            migrationBuilder.RenameTable(
                name: "AdviceTitle",
                newName: "AdviceTitles");

            migrationBuilder.RenameTable(
                name: "AdviceSubtitle",
                newName: "AdviceSubtitles");

            migrationBuilder.RenameIndex(
                name: "IX_AdviceTitle_AdviceTitleAdviceId",
                table: "AdviceTitles",
                newName: "IX_AdviceTitles_AdviceTitleAdviceId");

            migrationBuilder.RenameIndex(
                name: "IX_AdviceSubtitle_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitles",
                newName: "IX_AdviceSubtitles_AdviceSubtitleAdviceTitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdviceTitles",
                table: "AdviceTitles",
                column: "AdviceTitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdviceSubtitles",
                table: "AdviceSubtitles",
                column: "AdviceSubtitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdviceSubtitles_AdviceTitles_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitles",
                column: "AdviceSubtitleAdviceTitleId",
                principalTable: "AdviceTitles",
                principalColumn: "AdviceTitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdviceTitles_Advices_AdviceTitleAdviceId",
                table: "AdviceTitles",
                column: "AdviceTitleAdviceId",
                principalTable: "Advices",
                principalColumn: "AdviceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdviceSubtitles_AdviceTitles_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdviceTitles_Advices_AdviceTitleAdviceId",
                table: "AdviceTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdviceTitles",
                table: "AdviceTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdviceSubtitles",
                table: "AdviceSubtitles");

            migrationBuilder.RenameTable(
                name: "AdviceTitles",
                newName: "AdviceTitle");

            migrationBuilder.RenameTable(
                name: "AdviceSubtitles",
                newName: "AdviceSubtitle");

            migrationBuilder.RenameIndex(
                name: "IX_AdviceTitles_AdviceTitleAdviceId",
                table: "AdviceTitle",
                newName: "IX_AdviceTitle_AdviceTitleAdviceId");

            migrationBuilder.RenameIndex(
                name: "IX_AdviceSubtitles_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitle",
                newName: "IX_AdviceSubtitle_AdviceSubtitleAdviceTitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdviceTitle",
                table: "AdviceTitle",
                column: "AdviceTitleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdviceSubtitle",
                table: "AdviceSubtitle",
                column: "AdviceSubtitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdviceSubtitle_AdviceTitle_AdviceSubtitleAdviceTitleId",
                table: "AdviceSubtitle",
                column: "AdviceSubtitleAdviceTitleId",
                principalTable: "AdviceTitle",
                principalColumn: "AdviceTitleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdviceTitle_Advices_AdviceTitleAdviceId",
                table: "AdviceTitle",
                column: "AdviceTitleAdviceId",
                principalTable: "Advices",
                principalColumn: "AdviceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
