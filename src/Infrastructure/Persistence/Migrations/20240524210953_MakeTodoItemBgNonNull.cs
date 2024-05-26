using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo_App.Infrastructure.Persistence.Migrations
{
    public partial class MakeTodoItemBgNonNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColour_Code",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BackgroundColour_Code",
                table: "TodoItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
