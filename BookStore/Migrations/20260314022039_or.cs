using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class or : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.DropIndex(
                name: "IX_book_OrderItemsId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "OrderItemsId",
                table: "book");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_Bookid",
                table: "orderItems",
                column: "Bookid");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_book_Bookid",
                table: "orderItems",
                column: "Bookid",
                principalTable: "book",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_book_Bookid",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_Bookid",
                table: "orderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemsId",
                table: "book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_OrderItemsId",
                table: "book",
                column: "OrderItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_orderItems_OrderItemsId",
                table: "book",
                column: "OrderItemsId",
                principalTable: "orderItems",
                principalColumn: "OrderItemsId");
        }
    }
}
