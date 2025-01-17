using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnilsonSolution.Migrations
{
    public partial class AlterTankVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tank",
                table: "Tank");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Tank");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Tank");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tank");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tank");

            migrationBuilder.RenameTable(
                name: "Tank",
                newName: "Tanque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tanque",
                table: "Tanque",
                column: "Deposito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tanque",
                table: "Tanque");

            migrationBuilder.RenameTable(
                name: "Tanque",
                newName: "Tank");

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Tank",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Tank",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Tank",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tank",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tank",
                table: "Tank",
                column: "Deposito");
        }
    }
}
