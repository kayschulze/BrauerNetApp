using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrauerNetApp.Data.Migrations
{
    public partial class ProjectModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModuleProjects",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleProjects", x => new { x.ModuleId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ModuleProjects_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ProjectId",
                table: "Modules",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleProjects_ProjectId",
                table: "ModuleProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Projects_ProjectId",
                table: "Modules",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Projects_ProjectId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "ModuleProjects");

            migrationBuilder.DropIndex(
                name: "IX_Modules_ProjectId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Modules");
        }
    }
}
