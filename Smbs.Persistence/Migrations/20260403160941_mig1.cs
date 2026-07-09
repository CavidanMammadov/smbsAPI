using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogModule_Blogs_BlogModuleBlogId",
                table: "BlogModule");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgram_Trainers_TrainingProgramTrainerId",
                table: "TrainingProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingProgram",
                table: "TrainingProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogModule",
                table: "BlogModule");

            migrationBuilder.RenameTable(
                name: "TrainingProgram",
                newName: "TrainingPrograms");

            migrationBuilder.RenameTable(
                name: "BlogModule",
                newName: "BlogModules");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgram_TrainingProgramTrainerId",
                table: "TrainingPrograms",
                newName: "IX_TrainingPrograms_TrainingProgramTrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogModule_BlogModuleBlogId",
                table: "BlogModules",
                newName: "IX_BlogModules_BlogModuleBlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPrograms",
                table: "TrainingPrograms",
                column: "TrainingProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogModules",
                table: "BlogModules",
                column: "BlogModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogModules_Blogs_BlogModuleBlogId",
                table: "BlogModules",
                column: "BlogModuleBlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingPrograms_Trainers_TrainingProgramTrainerId",
                table: "TrainingPrograms",
                column: "TrainingProgramTrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogModules_Blogs_BlogModuleBlogId",
                table: "BlogModules");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingPrograms_Trainers_TrainingProgramTrainerId",
                table: "TrainingPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPrograms",
                table: "TrainingPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogModules",
                table: "BlogModules");

            migrationBuilder.RenameTable(
                name: "TrainingPrograms",
                newName: "TrainingProgram");

            migrationBuilder.RenameTable(
                name: "BlogModules",
                newName: "BlogModule");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingPrograms_TrainingProgramTrainerId",
                table: "TrainingProgram",
                newName: "IX_TrainingProgram_TrainingProgramTrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogModules_BlogModuleBlogId",
                table: "BlogModule",
                newName: "IX_BlogModule_BlogModuleBlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingProgram",
                table: "TrainingProgram",
                column: "TrainingProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogModule",
                table: "BlogModule",
                column: "BlogModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogModule_Blogs_BlogModuleBlogId",
                table: "BlogModule",
                column: "BlogModuleBlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgram_Trainers_TrainingProgramTrainerId",
                table: "TrainingProgram",
                column: "TrainingProgramTrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
