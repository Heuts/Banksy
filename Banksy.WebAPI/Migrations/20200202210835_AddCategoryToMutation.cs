﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Banksy.WebAPI.Migrations
{
    public partial class AddCategoryToMutation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Mutations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Housing" },
                    { 2, null, "Transportation" },
                    { 3, null, "Groceries" },
                    { 4, null, "Utilities" },
                    { 5, null, "Insurance" },
                    { 6, null, "Medical and Healthcare" },
                    { 7, null, "Saving, Investing and Debt payments" },
                    { 8, null, "Personal spending" },
                    { 9, null, "Recreation and Entertainment" },
                    { 10, null, "Miscellaneous" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mutations_categoryId",
                table: "Mutations",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mutations_Category_categoryId",
                table: "Mutations",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mutations_Category_categoryId",
                table: "Mutations");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Mutations_categoryId",
                table: "Mutations");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Mutations");
        }
    }
}
