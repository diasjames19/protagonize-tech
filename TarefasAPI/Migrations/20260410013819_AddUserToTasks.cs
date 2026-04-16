using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TasksItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TasksItems_UserId",
                table: "TasksItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksItems_Users_UserId",
                table: "TasksItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksItems_Users_UserId",
                table: "TasksItems");

            migrationBuilder.DropIndex(
                name: "IX_TasksItems_UserId",
                table: "TasksItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TasksItems");
        }
    }
}
