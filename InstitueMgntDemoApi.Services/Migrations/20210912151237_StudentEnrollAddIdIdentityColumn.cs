using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitueMgntDemoApi.Services.Migrations
{
    public partial class StudentEnrollAddIdIdentityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrolls",
                table: "StudentEnrolls");

            migrationBuilder.DeleteData(
                table: "StudentEnrolls",
                keyColumn: "StudentEnrollId",
                keyValue: "21STDCSE001");

            migrationBuilder.AlterColumn<string>(
                name: "StudentEnrollId",
                table: "StudentEnrolls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentEnrolls",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrolls",
                table: "StudentEnrolls",
                column: "Id");

            migrationBuilder.InsertData(
                table: "StudentEnrolls",
                columns: new[] { "Id", "BranchId", "Section", "Semester", "StudentEnrollId", "StudentInfoId" },
                values: new object[] { 1, 1, 0, 0, "21STUCSE00001", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentEnrolls",
                table: "StudentEnrolls");

            migrationBuilder.DeleteData(
                table: "StudentEnrolls",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentEnrolls");

            migrationBuilder.AlterColumn<string>(
                name: "StudentEnrollId",
                table: "StudentEnrolls",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentEnrolls",
                table: "StudentEnrolls",
                column: "StudentEnrollId");

            migrationBuilder.InsertData(
                table: "StudentEnrolls",
                columns: new[] { "StudentEnrollId", "BranchId", "Section", "Semester", "StudentInfoId" },
                values: new object[] { "21STDCSE001", 1, 0, 0, 1 });
        }
    }
}
