using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employments_Name",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchOfficeId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmploymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employments_DepartmentId_Name",
                table: "Employments",
                columns: new[] { "DepartmentId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchOfficeId_Name",
                table: "Departments",
                columns: new[] { "BranchOfficeId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmploymentId_Name",
                table: "Employees",
                columns: new[] { "EmploymentId", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_BranchOffices_BranchOfficeId",
                table: "Departments",
                column: "BranchOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Departments_DepartmentId",
                table: "Employments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_BranchOffices_BranchOfficeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Departments_DepartmentId",
                table: "Employments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employments_DepartmentId_Name",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_BranchOfficeId_Name",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "BranchOfficeId",
                table: "Departments");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_Name",
                table: "Employments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);
        }
    }
}
