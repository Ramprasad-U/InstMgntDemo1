using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitueMgntDemoApi.Services.Migrations
{
    public partial class Attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subBelongsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_AttendanceDetails_SubjectBelongsTos_subBelongsId",
                        column: x => x.subBelongsId,
                        principalTable: "SubjectBelongsTos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attId = table.Column<int>(type: "int", nullable: false),
                    enrollId = table.Column<int>(type: "int", nullable: false),
                    attendanceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.id);
                    table.ForeignKey(
                        name: "FK_Attendances_AttendanceDetails_attId",
                        column: x => x.attId,
                        principalTable: "AttendanceDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_StudentEnrolls_enrollId",
                        column: x => x.enrollId,
                        principalTable: "StudentEnrolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetails_subBelongsId",
                table: "AttendanceDetails",
                column: "subBelongsId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_attId",
                table: "Attendances",
                column: "attId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_enrollId",
                table: "Attendances",
                column: "enrollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AttendanceDetails");
        }
    }
}
