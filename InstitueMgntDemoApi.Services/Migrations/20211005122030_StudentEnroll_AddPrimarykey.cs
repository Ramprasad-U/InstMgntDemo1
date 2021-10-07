using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitueMgntDemoApi.Services.Migrations
{
    public partial class StudentEnroll_AddPrimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
              name: "PK_StudentEnrolls",
              table: "StudentEnrolls",
              column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrolls",
                table: "StudentEnrolls");
        }
    }
}
