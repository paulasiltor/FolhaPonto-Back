using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolhaPonto.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UsersId");

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    CollaboratorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.CollaboratorsId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectsId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TasksId);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "ProjectsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackers",
                columns: table => new
                {
                    TimeTrackersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeZoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollaboratorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackers", x => x.TimeTrackersId);
                    table.ForeignKey(
                        name: "FK_TimeTrackers_Collaborators_CollaboratorsId",
                        column: x => x.CollaboratorsId,
                        principalTable: "Collaborators",
                        principalColumn: "CollaboratorsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTrackers_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "TasksId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectsId",
                table: "Tasks",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackers_CollaboratorsId",
                table: "TimeTrackers",
                column: "CollaboratorsId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackers_TasksId",
                table: "TimeTrackers",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTrackers");

            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Users",
                newName: "Id");
        }
    }
}
