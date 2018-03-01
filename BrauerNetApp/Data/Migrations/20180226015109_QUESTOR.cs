using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrauerNetApp.Data.Migrations
{
    public partial class QUESTOR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "ModuleProjects");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Steps",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Steps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Standards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QUESTORId",
                table: "Stakeholders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QUESTORId",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QUESTORId",
                table: "Goals",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QUESTORs",
                columns: table => new
                {
                    QUESTORId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTORs", x => x.QUESTORId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ProjectId",
                table: "Steps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_ProjectId",
                table: "Standards",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_QUESTORId",
                table: "Stakeholders",
                column: "QUESTORId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_QUESTORId",
                table: "Modules",
                column: "QUESTORId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_QUESTORId",
                table: "Goals",
                column: "QUESTORId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_ProjectId",
                table: "Responses",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals",
                column: "QUESTORId",
                principalTable: "QUESTORs",
                principalColumn: "QUESTORId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_QUESTORs_QUESTORId",
                table: "Modules",
                column: "QUESTORId",
                principalTable: "QUESTORs",
                principalColumn: "QUESTORId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stakeholders_QUESTORs_QUESTORId",
                table: "Stakeholders",
                column: "QUESTORId",
                principalTable: "QUESTORs",
                principalColumn: "QUESTORId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Standards_Projects_ProjectId",
                table: "Standards",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Projects_ProjectId",
                table: "Steps",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_QUESTORs_QUESTORId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_QUESTORs_QUESTORId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Stakeholders_QUESTORs_QUESTORId",
                table: "Stakeholders");

            migrationBuilder.DropForeignKey(
                name: "FK_Standards_Projects_ProjectId",
                table: "Standards");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Projects_ProjectId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "QUESTORs");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Steps_ProjectId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Standards_ProjectId",
                table: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Stakeholders_QUESTORId",
                table: "Stakeholders");

            migrationBuilder.DropIndex(
                name: "IX_Modules_QUESTORId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Goals_QUESTORId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "QUESTORId",
                table: "Stakeholders");

            migrationBuilder.DropColumn(
                name: "QUESTORId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "QUESTORId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Steps",
                nullable: true,
                oldClrType: typeof(int));

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
                name: "IX_ModuleProjects_ProjectId",
                table: "ModuleProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Modules_ModuleId",
                table: "Steps",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
