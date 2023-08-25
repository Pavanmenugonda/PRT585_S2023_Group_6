using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applicant_Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applicant_BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applicant_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Applicant_ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    ApplicationStatusID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationStatus_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationStatus_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationtStatus_ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.ApplicationStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade_Number = table.Column<int>(type: "int", nullable: false),
                    Grade_Capacity = table.Column<int>(type: "int", nullable: false),
                    Grade_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade_ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantID = table.Column<long>(type: "bigint", nullable: false),
                    GradeID = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationStatusID = table.Column<long>(type: "bigint", nullable: false),
                    Application_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Application_ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStatuses_ApplicationStatusID",
                        column: x => x.ApplicationStatusID,
                        principalTable: "ApplicationStatuses",
                        principalColumn: "ApplicationStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Grades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantID",
                table: "Applications",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusID",
                table: "Applications",
                column: "ApplicationStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_GradeID",
                table: "Applications",
                column: "GradeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
