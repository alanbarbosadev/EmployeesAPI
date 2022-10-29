using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deparment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Deparment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deparment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Marketing" },
                    { 2, "Accounting" },
                    { 3, "Finances" },
                    { 4, "Sales" },
                    { 5, "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Birthday", "DepartmentId", "Name", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, "Alan", 1500m, "Barbosa" },
                    { 2, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, "Vanessa", 1750m, "Barbosa" },
                    { 3, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, "Alex", 2000m, "Cavalcante" },
                    { 4, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 2, "Uedemide", 2250m, "Lopes" },
                    { 5, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, "Taylinne", 2500m, "Oliveira" },
                    { 6, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 3, "Erivan", 2750m, "Cavalcante" },
                    { 7, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, "Edvaldo", 3000m, "Barbosa" },
                    { 8, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 4, "Eliza", 3250m, "Rabay" },
                    { 9, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, "Edgar", 3500m, "Poe" },
                    { 10, new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Local), 5, "Stephen", 3750m, "King" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Deparment");
        }
    }
}
