﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserServiceAPI.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Position" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "Developer" },
                    { 2, "jane.smith@example.com", "Jane Smith", "Manager" },
                    { 3, "sara.taylor@example.com", "Sara Taylor", "Manager" },
                    { 4, "pam.jordon@example.com", "Pam Jordon", "Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
