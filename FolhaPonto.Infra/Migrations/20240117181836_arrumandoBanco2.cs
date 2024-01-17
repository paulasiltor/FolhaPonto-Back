using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolhaPonto.Infra.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoBanco2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTrackers_Collaborators_CollaboratorsId",
                table: "TimeTrackers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollaboratorsId",
                table: "TimeTrackers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTrackers_Collaborators_CollaboratorsId",
                table: "TimeTrackers",
                column: "CollaboratorsId",
                principalTable: "Collaborators",
                principalColumn: "CollaboratorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTrackers_Collaborators_CollaboratorsId",
                table: "TimeTrackers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CollaboratorsId",
                table: "TimeTrackers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTrackers_Collaborators_CollaboratorsId",
                table: "TimeTrackers",
                column: "CollaboratorsId",
                principalTable: "Collaborators",
                principalColumn: "CollaboratorsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
