using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo_App.Infrastructure.Persistence.Migrations
{
    public partial class MakeTagSingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTodoItem");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TagId",
                table: "TodoItems",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Tags_TagId",
                table: "TodoItems",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Tags_TagId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TagId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "TodoItems");

            migrationBuilder.CreateTable(
                name: "TagTodoItem",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TodoItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTodoItem", x => new { x.TagsId, x.TodoItemsId });
                    table.ForeignKey(
                        name: "FK_TagTodoItem_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTodoItem_TodoItems_TodoItemsId",
                        column: x => x.TodoItemsId,
                        principalTable: "TodoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTodoItem_TodoItemsId",
                table: "TagTodoItem",
                column: "TodoItemsId");
        }
    }
}
