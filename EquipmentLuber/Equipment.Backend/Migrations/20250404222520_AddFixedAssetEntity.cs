using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equipment.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddFixedAssetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FixedAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmploymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedAssets_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFixedAsset",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    FixedAssetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFixedAsset", x => new { x.EmployeesId, x.FixedAssetsId });
                    table.ForeignKey(
                        name: "FK_EmployeeFixedAsset_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeFixedAsset_FixedAssets_FixedAssetsId",
                        column: x => x.FixedAssetsId,
                        principalTable: "FixedAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFixedAsset_FixedAssetsId",
                table: "EmployeeFixedAsset",
                column: "FixedAssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssets_EmploymentId_Name",
                table: "FixedAssets",
                columns: new[] { "EmploymentId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFixedAsset");

            migrationBuilder.DropTable(
                name: "FixedAssets");
        }
    }
}
