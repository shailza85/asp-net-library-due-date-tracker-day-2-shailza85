using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksTracker.Migrations
{
    public partial class UpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1977, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -5,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(288), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -4,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(252), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(28), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1,
                columns: new[] { "CheckedOutDate", "DueDate", "PublicationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(6), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(183) });
        }
    }
}
