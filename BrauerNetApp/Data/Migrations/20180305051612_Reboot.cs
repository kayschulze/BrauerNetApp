using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrauerNetApp.Data.Migrations
{
    public partial class Reboot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "GoalProject");

            migrationBuilder.DropIndex(
                name: "IX_Steps_ModuleId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Steps");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QUESTORId",
                table: "Goals",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals",
                column: "QUESTORId",
                principalTable: "QUESTORs",
                principalColumn: "QUESTORId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Steps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "QUESTORId",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "GoalProject",
                columns: table => new
                {
                    GoalId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalProject", x => new { x.GoalId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_GoalProject_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ModuleId",
                table: "Steps",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalProject_ProjectId",
                table: "GoalProject",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals",
                column: "QUESTORId",
                principalTable: "QUESTORs",
                principalColumn: "QUESTORId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
