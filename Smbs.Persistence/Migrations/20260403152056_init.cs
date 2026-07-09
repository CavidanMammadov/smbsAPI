using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smbs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    AboutUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutUsImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.AboutUsId);
                });

            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdviceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdviceContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdviceCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdviceDuration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.AdviceId);
                });

            migrationBuilder.CreateTable(
                name: "Applyments",
                columns: table => new
                {
                    ApplymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplymentNameAndSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplymentPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplymentType = table.Column<int>(type: "int", nullable: false),
                    ApplymentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplymentTrainingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applyments", x => x.ApplymentId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNameAndSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCertificateType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCertificateTraining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentTrainingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCertificateGivingTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "HeroSections",
                columns: table => new
                {
                    HeroSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroSectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroSectionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSections", x => x.HeroSectionId);
                });

            migrationBuilder.CreateTable(
                name: "LandingPages",
                columns: table => new
                {
                    LandingPageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandingPageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingPageImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingPageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingPageButton = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingPages", x => x.LandingPageId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageNameAndSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessagePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "MissionAndVisions",
                columns: table => new
                {
                    MissionAndVisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionAndVisionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionAndVisionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionAndVisionIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionAndVisions", x => x.MissionAndVisionId);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDownloadings",
                columns: table => new
                {
                    ProgramDownloadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramDownloadingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDownloadingSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDownloadingEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDownloadingBrochureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDownloadingPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDownloadings", x => x.ProgramDownloadingId);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshTokenToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpireIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    SocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.SocialMediaId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerNameAndSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerTrainingVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingGroupSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingCoveredTopics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingWorkOpportunity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "BlogModule",
                columns: table => new
                {
                    BlogModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogModuleContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogModuleBlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogModule", x => x.BlogModuleId);
                    table.ForeignKey(
                        name: "FK_BlogModule_Blogs_BlogModuleBlogId",
                        column: x => x.BlogModuleBlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    TrainingProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingProgramTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingProgramDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingProgramTrainerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.TrainingProgramId);
                    table.ForeignKey(
                        name: "FK_TrainingProgram_Trainers_TrainingProgramTrainerId",
                        column: x => x.TrainingProgramTrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "UserRoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Trainer" },
                    { 3, "Student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogModule_BlogModuleBlogId",
                table: "BlogModule",
                column: "BlogModuleBlogId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgram_TrainingProgramTrainerId",
                table: "TrainingProgram",
                column: "TrainingProgramTrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "Applyments");

            migrationBuilder.DropTable(
                name: "BlogModule");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "HeroSections");

            migrationBuilder.DropTable(
                name: "LandingPages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MissionAndVisions");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "ProgramDownloadings");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
