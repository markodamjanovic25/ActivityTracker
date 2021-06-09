using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLibrary.Migrations
{
    public partial class TableAndColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ActivityOptionId",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flag = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ActivityOptions",
                columns: new[] { "Id", "Description", "Flag" },
                values: new object[,]
                {
                    { 1, "just excercised!", "/img/ExcerciseFlag.svg" },
                    { 2, "just meditated!", "/img/MeditationFlag.svg" },
                    { 3, "just drank a glass of water!", "/img/WaterFlag.svg" },
                    { 4, "just read a chapter of a book!", "/img/BookFlag.svg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityOptionId",
                table: "Activities",
                column: "ActivityOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityOptions_ActivityOptionId",
                table: "Activities",
                column: "ActivityOptionId",
                principalTable: "ActivityOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityOptions_ActivityOptionId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityOptions");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityOptionId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityOptionId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityDetailsId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
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
    }
}
