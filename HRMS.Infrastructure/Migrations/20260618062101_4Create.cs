using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _4Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentIdDeptId",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ndI6gTkI4JOB7h5yykQXCe3VnOt4O.cnmmZUrN./nR6aaPY2x1xmi");

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DepartmentIdDeptId",
                table: "Designations",
                column: "DepartmentIdDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Designations_Departments_DepartmentIdDeptId",
                table: "Designations",
                column: "DepartmentIdDeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designations_Departments_DepartmentIdDeptId",
                table: "Designations");

            migrationBuilder.DropIndex(
                name: "IX_Designations_DepartmentIdDeptId",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "DepartmentIdDeptId",
                table: "Designations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$OgolUyLXXymhU1CTQvUMnOrDuedaJ5lS0sSaxYLaxC3D7i6TI.wN2");
        }
    }
}
