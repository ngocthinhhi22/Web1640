using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1640WebDevUMC.Data.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYears_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contributions",
                columns: table => new
                {
                    ContributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicYearId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalClosureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedForPublication = table.Column<bool>(type: "bit", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contributions", x => x.ContributionId);
                    table.ForeignKey(
                        name: "FK_contributions_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contributions_Accounts_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DownloadHistory",
                columns: table => new
                {
                    DownloadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketingManagerId = table.Column<int>(type: "int", nullable: true),
                    ContributionId = table.Column<int>(type: "int", nullable: true),
                    DownloadDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadHistory", x => x.DownloadId);
                    table.ForeignKey(
                        name: "FK_DownloadHistory_contributions_ContributionId",
                        column: x => x.ContributionId,
                        principalTable: "contributions",
                        principalColumn: "ContributionId");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContributionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_contributions_ContributionId",
                        column: x => x.ContributionId,
                        principalTable: "contributions",
                        principalColumn: "ContributionId");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionId = table.Column<int>(type: "int", nullable: true),
                    Image1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_contributions_ContributionId",
                        column: x => x.ContributionId,
                        principalTable: "contributions",
                        principalColumn: "ContributionId");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContributionId = table.Column<int>(type: "int", nullable: true),
                    RecipientUserId = table.Column<int>(type: "int", nullable: true),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecipientUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_Accounts_RecipientUserId1",
                        column: x => x.RecipientUserId1,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_contributions_ContributionId",
                        column: x => x.ContributionId,
                        principalTable: "contributions",
                        principalColumn: "ContributionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FacultyId",
                table: "Accounts",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_FacultyId",
                table: "AcademicYears",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_contributions_AcademicYearId",
                table: "contributions",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_contributions_UserId1",
                table: "contributions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadHistory_ContributionId",
                table: "DownloadHistory",
                column: "ContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ContributionId",
                table: "Files",
                column: "ContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ContributionId",
                table: "Images",
                column: "ContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ContributionId",
                table: "Notification",
                column: "ContributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RecipientUserId1",
                table: "Notification",
                column: "RecipientUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Faculties_FacultyId",
                table: "Accounts",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Faculties_FacultyId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "DownloadHistory");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "contributions");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_FacultyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Accounts");
        }
    }
}
