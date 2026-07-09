using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TrainerTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainerPosition",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainerPosition",
                table: "Trainers");
        }
    }
}
