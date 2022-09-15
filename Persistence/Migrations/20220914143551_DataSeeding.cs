using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7099), null, null, "For Legal Activities", false, 0, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7078), "Legal Department" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7142), null, null, "For Sanitation", false, 0, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7126), "Toilet Department" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Email", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7188), null, null, 1, "Employee1@gmail.com", false, 0, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7173), "Ganiyu Ganiyu" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "DepartmentId", "Email", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[] { 2, 1, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7240), null, null, 2, "Employee2@gmail.com", false, 0, new DateTime(2022, 9, 14, 14, 35, 50, 577, DateTimeKind.Utc).AddTicks(7219), "Abass Adebayo " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
