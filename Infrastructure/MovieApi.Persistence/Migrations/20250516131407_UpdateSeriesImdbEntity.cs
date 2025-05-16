using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeriesImdbEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SeriesImdbs");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 714, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 714, DateTimeKind.Local).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublicationDate" },
                values: new object[] { new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(3443), new DateTime(2025, 5, 16, 16, 14, 6, 715, DateTimeKind.Local).AddTicks(3440) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SeriesImdbs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 16, 0, 42, 29, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublicationDate" },
                values: new object[] { new DateTime(2025, 5, 16, 16, 0, 42, 30, DateTimeKind.Local).AddTicks(98), new DateTime(2025, 5, 16, 16, 0, 42, 30, DateTimeKind.Local).AddTicks(94) });
        }
    }
}
