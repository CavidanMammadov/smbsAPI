using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class iconDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionAndVisionIcon",
                table: "MissionAndVisions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MissionAndVisionIcon",
                table: "MissionAndVisions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
