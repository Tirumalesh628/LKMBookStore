using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "orderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "orderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemsId",
                table: "book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_orderItems_OrderItemsId",
                table: "book");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "date",
                table: "orderItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemsId",
                table: "book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_orderItems_OrderItemsId",
                table: "book",
                column: "OrderItemsId",
                principalTable: "orderItems",
                principalColumn: "OrderItemsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
