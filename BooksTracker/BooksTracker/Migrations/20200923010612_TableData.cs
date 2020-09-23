using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksTracker.Migrations
{
    public partial class TableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { -1, "Nora Roberts" },
                    { -2, "Stephen King" },
                    { -3, "Jane Austen" },
                    { -4, "Zadie Smith" },
                    { -5, "George Orewell" },
                    { -6, "Jess Kidd" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "CheckedOutDate", "DueDate", "PublicationDate", "ReturnedDate", "Title" },
                values: new object[,]
                {
                    { -1, -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(183), null, "Key of Light" },
                    { -2, -2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(200), null, "Once Upon a Rose" },
                    { -3, -3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(200), null, "Blue Smoke" },
                    { -4, -4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(28), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(179), null, "The Shining" },
                    { -5, -5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(288), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(223), null, "Doctor Sleep" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
