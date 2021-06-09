using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLibrary.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityDetailsId",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Activities",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActivityDetails",
                columns: new[] { "Id", "Description", "Flag" },
                values: new object[,]
                {
                    { 1, "just excercised!", "/img/ExcerciseFlag.svg" },
                    { 2, "just meditated!", "/img/MeditationFlag.svg" },
                    { 3, "just drank a glass of water!", "/img/WaterFlag.svg" },
                    { 4, "just read a chapter of a book!", "/img/BookFlag.svg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityDetailsId",
                table: "Activities",
                column: "ActivityDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityDetails_ActivityDetailsId",
                table: "Activities",
                column: "ActivityDetailsId",
                principalTable: "ActivityDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityDetails_ActivityDetailsId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityDetails");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityDetailsId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityDetailsId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Activities",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Flag" },
                values: new object[,]
                {
                    { 1, "just excercised!", "/img/ExcerciseFlag.svg" },
                    { 2, "just meditated!", "/img/MeditationFlag.svg" },
                    { 3, "just drank a glass of water!", "/img/WaterFlag.svg" },
                    { 4, "just read a chapter of a book!", "/img/BookFlag.svg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ActivityId",
                table: "Tasks",
                column: "ActivityId");
        }
    }
}
