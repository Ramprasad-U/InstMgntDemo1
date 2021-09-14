using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitueMgntDemoApi.Services.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    StudentInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBrith = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.StudentInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpGender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable:false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    StudentEnrollId = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    StudentInfoId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrolls_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrolls_StudentInfos_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "StudentInfos",
                        principalColumn: "StudentInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectBelongsTos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Sem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectBelongsTos", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubjectBelongsTos_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectBelongsTos_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyAssignToSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    SubjectBelongsToId = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyAssignToSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacultyAssignToSubjects_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyAssignToSubjects_SubjectBelongsTos_SubjectBelongsToId",
                        column: x => x.SubjectBelongsToId,
                        principalTable: "SubjectBelongsTos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "BranchCode", "BranchName" },
                values: new object[,]
                {
                    { 1, "CSE", "Computer Science Engineering" },
                    { 2, "MEC", "Mechanical Engineering" },
                    { 3, "ECE", "Electronic Communication Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Faculty" },
                    { 2, "Administator" }
                });

            migrationBuilder.InsertData(
                table: "StudentInfos",
                columns: new[] { "StudentInfoId", "DateOfBrith", "Email", "Gender", "Name" },
                values: new object[] { 1, new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aurora@gmail.com", 1, "Aurora" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectCode", "SubjectName" },
                values: new object[,]
                {
                    { 1, "CN201", "Computer Networks" },
                    { 2, "MA100", "Mathematics" },
                    { 3, "OOP102", "ObjectOrientedPrograming" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DepartmentId", "EmpEmail", "EmpGender", "EmpName" },
                values: new object[,]
                {
                    { 1, 1, "John@gmail.com", 0, "John" },
                    { 2, 2, "chris@gmail.com", 0, "Chris" }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrolls",
                columns: new[] { "StudentEnrollId", "BranchId", "Section", "Semester", "StudentInfoId" },
                values: new object[] { "21STDCSE001", 1, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "SubjectBelongsTos",
                columns: new[] { "id", "BranchId", "Sem", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1, 2, 1 },
                    { 2, 1, 0, 2 },
                    { 3, 3, 0, 2 },
                    { 4, 2, 0, 2 },
                    { 5, 1, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "FacultyAssignToSubjects",
                columns: new[] { "Id", "EmpId", "Section", "SubjectBelongsToId" },
                values: new object[] { 1, 1, 0, 1 });

            migrationBuilder.InsertData(
                table: "FacultyAssignToSubjects",
                columns: new[] { "Id", "EmpId", "Section", "SubjectBelongsToId" },
                values: new object[] { 2, 1, 0, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyAssignToSubjects_EmpId",
                table: "FacultyAssignToSubjects",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyAssignToSubjects_SubjectBelongsToId",
                table: "FacultyAssignToSubjects",
                column: "SubjectBelongsToId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolls_BranchId",
                table: "StudentEnrolls",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrolls_StudentInfoId",
                table: "StudentEnrolls",
                column: "StudentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectBelongsTos_BranchId",
                table: "SubjectBelongsTos",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectBelongsTos_SubjectId",
                table: "SubjectBelongsTos",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyAssignToSubjects");

            migrationBuilder.DropTable(
                name: "StudentEnrolls");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SubjectBelongsTos");

            migrationBuilder.DropTable(
                name: "StudentInfos");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
