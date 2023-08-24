using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShopApp.Migrations
{
    /// <inheritdoc />
    public partial class temp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Count", "Title" },
                values: new object[,]
                {
                    { 1, "Harper Lee", 57, "To Kill a Mockingbird" },
                    { 2, "George Orwell", 20, "1984" },
                    { 3, "F. Scott Fitzgerald", 60, "The Great Gatsby" },
                    { 4, "Jane Austen", 37, "Pride and Prejudice" },
                    { 5, "J.D. Salinger", 2, "The Catcher in the Rye" }
                });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "Id", "BookId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Classic novel by Harper Lee." },
                    { 2, 2, "Dystopian masterpiece by George Orwell." },
                    { 3, 3, "F. Scott Fitzgerald's Jazz Age novel." },
                    { 4, 4, "Jane Austen's timeless love story." },
                    { 5, 5, "J.D. Salinger's coming-of-age classic." }
                });
        }
    }
}
