using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3359), null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3339), "For Legal Activities", false, null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3320), "Legal Department" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3422), null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3407), "For Sanitation", false, null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3392), "Toilet Department" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Email", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3796), null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3780), 1, "Employee1@gmail.com", false, null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3761), "Ganiyu Ganiyu" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Email", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3860), null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3844), 2, "Employee2@gmail.com", false, null, new DateTime(2022, 9, 15, 10, 42, 24, 934, DateTimeKind.Utc).AddTicks(3830), "Abass Adebayo " });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
