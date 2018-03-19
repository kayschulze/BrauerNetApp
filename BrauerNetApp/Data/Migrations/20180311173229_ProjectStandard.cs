using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrauerNetApp.Data.Migrations
{
    public partial class ProjectStandard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standards_Projects_ProjectId",
                table: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Standards_ProjectId",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectStandard",
                columns: table => new
                {
                    StandardId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStandard", x => new { x.StandardId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectStandard_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectStandard_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStandard_ProjectId",
                table: "ProjectStandard",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectStandard");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Standards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_ProjectId",
                table: "Standards",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Standards_Projects_ProjectId",
                table: "Standards",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
