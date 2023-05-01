using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabbTwo.Migrations
{
    /// <inheritdoc />
    public partial class schools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.SchoolClassId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolConnections",
                columns: table => new
                {
                    SchoolConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_CourseId = table.Column<int>(type: "int", nullable: false),
                    FK_EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FK_StudentId = table.Column<int>(type: "int", nullable: false),
                    FK_SchoolClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolConnections", x => x.SchoolConnectionId);
                    table.ForeignKey(
                        name: "FK_SchoolConnections_Courses_FK_CourseId",
                        column: x => x.FK_CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolConnections_Employees_FK_EmployeeId",
                        column: x => x.FK_EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolConnections_SchoolClasses_FK_SchoolClassId",
                        column: x => x.FK_SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolConnections_Students_FK_StudentId",
                        column: x => x.FK_StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolConnections_FK_CourseId",
                table: "SchoolConnections",
                column: "FK_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolConnections_FK_EmployeeId",
                table: "SchoolConnections",
                column: "FK_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolConnections_FK_SchoolClassId",
                table: "SchoolConnections",
                column: "FK_SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolConnections_FK_StudentId",
                table: "SchoolConnections",
                column: "FK_StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolConnections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
