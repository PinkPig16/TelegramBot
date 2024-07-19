using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramParse.Migrations
{
    /// <inheritdoc />
    public partial class appUserProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacancies_appUsers_UserId",
                table: "vacancies");

            migrationBuilder.DropIndex(
                name: "IX_vacancies_UserId",
                table: "vacancies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "vacancies");

            migrationBuilder.AlterColumn<long>(
                name: "AppUserId",
                table: "vacancies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_AppUserId",
                table: "vacancies",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacancies_appUsers_AppUserId",
                table: "vacancies",
                column: "AppUserId",
                principalTable: "appUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacancies_appUsers_AppUserId",
                table: "vacancies");

            migrationBuilder.DropIndex(
                name: "IX_vacancies_AppUserId",
                table: "vacancies");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "vacancies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "vacancies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_vacancies_UserId",
                table: "vacancies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacancies_appUsers_UserId",
                table: "vacancies",
                column: "UserId",
                principalTable: "appUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
