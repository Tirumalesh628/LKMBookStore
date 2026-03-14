using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class cartitemsadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_book_CartId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "bookid",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "book");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    CartItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartid = table.Column<int>(type: "int", nullable: true),
                    bookid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.CartItemsId);
                    table.ForeignKey(
                        name: "FK_cartItems_book_bookid",
                        column: x => x.bookid,
                        principalTable: "book",
                        principalColumn: "BookID");
                    table.ForeignKey(
                        name: "FK_cartItems_cart_cartid",
                        column: x => x.cartid,
                        principalTable: "cart",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_bookid",
                table: "cartItems",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_cartid",
                table: "cartItems",
                column: "cartid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.AddColumn<int>(
                name: "bookid",
                table: "cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_CartId",
                table: "book",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_book_cart_CartId",
                table: "book",
                column: "CartId",
                principalTable: "cart",
                principalColumn: "CartId");
        }
    }
}
