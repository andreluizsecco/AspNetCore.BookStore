using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore.Bookstore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(type: "varchar(150)", nullable: false),
                    Author = table.Column<string>(type: "varchar(150)", nullable: false),
                    Category = table.Column<string>(type: "varchar(150)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "numeric(38,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "ID", "Author", "Category", "CreatedDate", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Eric Evans", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 537, DateTimeKind.Local).AddTicks(3478), 59.90m, 26, "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { 2, "Robert C. Martin", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7448), 45.90m, 13, "Agile Principles, Patterns, and Practices in C#" },
                    { 3, "Robert C. Martin", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7475), 33.90m, 10, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 4, "Vaughn Vernon", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7478), 59.90m, 22, "Implementing Domain-Driven Design" },
                    { 5, "Scott Millet", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7481), 42.90m, 15, "Patterns, Principles, and Practices of Domain-Driven Design" },
                    { 6, "Martin Fowler", "Software", new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7483), 31.90m, 5, "Refactoring: Improving the Design of Existing Code" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
