using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SocialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrainingTeacherCertificate",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerTrainingVideoUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SocialMediaImage",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentCreatedAt",
                table: "Certificates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentScore",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Certificates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdviceImage",
                table: "Advices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TrainerId",
                table: "Certificates",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Trainers_TrainerId",
                table: "Certificates",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Trainers_TrainerId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_TrainerId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "SocialMediaImage",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "StudentCreatedAt",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "StudentScore",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "AdviceImage",
                table: "Advices");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingTeacherCertificate",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrainerTrainingVideoUrl",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
