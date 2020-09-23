using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksTracker.Migrations
{
    public partial class UpdateDueDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5,
                column: "DueDate",
                value: new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4,
                column: "DueDate",
                value: new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3,
                column: "DueDate",
                value: new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2,
                column: "DueDate",
                value: new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1,
                column: "DueDate",
                value: new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5,
                column: "DueDate",
                value: new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4,
                column: "DueDate",
                value: new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3,
                column: "DueDate",
                value: new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2,
                column: "DueDate",
                value: new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1,
                column: "DueDate",
                value: new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
