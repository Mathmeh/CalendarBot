using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CalendarBot.Migrations
{
    /// <inheritdoc />
    public partial class InititalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcelInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false),
                    Discipline = table.Column<string>(type: "text", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    LessonType = table.Column<string>(type: "text", nullable: false),
                    Hours = table.Column<double>(type: "double precision", nullable: false),
                    Ante = table.Column<double>(type: "double precision", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeacherName = table.Column<string>(type: "text", nullable: false),
                    Ante = table.Column<int>(type: "integer", nullable: false),
                    AcademicDiscipline = table.Column<string>(type: "text", nullable: false),
                    Faculty = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    EducationForm = table.Column<string>(type: "text", nullable: false),
                    StudentAmount = table.Column<int>(type: "integer", nullable: false),
                    Groups = table.Column<int>(type: "integer", nullable: false),
                    Subgroups = table.Column<int>(type: "integer", nullable: false),
                    Lectures = table.Column<int>(type: "integer", nullable: false),
                    OfflineLectures = table.Column<int>(type: "integer", nullable: false),
                    SemLessons = table.Column<int>(type: "integer", nullable: false),
                    SemLessonsOffline = table.Column<int>(type: "integer", nullable: false),
                    LabLesson = table.Column<int>(type: "integer", nullable: false),
                    LabLessonOffline = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTests = table.Column<int>(type: "integer", nullable: false),
                    USRControl = table.Column<int>(type: "integer", nullable: false),
                    ControlWorks = table.Column<int>(type: "integer", nullable: false),
                    Exams = table.Column<double>(type: "double precision", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    EducationalPractice = table.Column<double>(type: "double precision", nullable: false),
                    Internship = table.Column<double>(type: "double precision", nullable: false),
                    CourseProject = table.Column<double>(type: "double precision", nullable: false),
                    GraduationProject = table.Column<double>(type: "double precision", nullable: false),
                    UnderGraduatesLessons = table.Column<double>(type: "double precision", nullable: false),
                    DepartmentManagement = table.Column<double>(type: "double precision", nullable: false),
                    GEX = table.Column<double>(type: "double precision", nullable: false),
                    TotalHours = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcelInfos");

            migrationBuilder.DropTable(
                name: "Implementations");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
