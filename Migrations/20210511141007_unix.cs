using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PakketService.Migrations
{
    public partial class unix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ticket");

            migrationBuilder.AddColumn<double>(
                name: "CreatedAt",
                table: "Ticket",
                type: "float",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "CreatedAt",
              table: "Ticket");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }
    }
}
