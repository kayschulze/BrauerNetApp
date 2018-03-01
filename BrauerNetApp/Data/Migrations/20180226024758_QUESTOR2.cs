using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrauerNetApp.Data.Migrations
{
    public partial class QUESTOR2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Projects_ProjectId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_ProjectId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ModuleId",
                table: "Projects",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ModuleId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ProjectId",
                table: "Modules",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Projects_ProjectId",
                table: "Modules",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
