using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Task",
                table: "ToDos");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ToDos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ToDos");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Task",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
