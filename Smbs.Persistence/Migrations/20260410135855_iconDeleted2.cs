using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class iconDeleted2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyIcon",
                table: "Policies");

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaUrl",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialMediaUrl",
                table: "SocialMedias");

            migrationBuilder.AddColumn<string>(
                name: "PolicyIcon",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
