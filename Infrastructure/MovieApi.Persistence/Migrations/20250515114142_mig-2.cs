using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Directors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Actors",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(5261), "John Smith" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(5264), "Emily Blunt" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(7357), "Cristopher Nolan" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublicationDate" },
                values: new object[] { new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(9340), new DateTime(2025, 5, 15, 14, 41, 42, 205, DateTimeKind.Local).AddTicks(9336) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Directors",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Actors",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "Surname" },
                values: new object[] { new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(3909), "John", "Smith" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name", "Surname" },
                values: new object[] { new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(3912), "Emily", "Blunt" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "Surname" },
                values: new object[] { new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(6008), "Cristopher", "Nolan" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(6942));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PublicationDate" },
                values: new object[] { new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(7934), new DateTime(2025, 5, 12, 21, 36, 15, 76, DateTimeKind.Local).AddTicks(7931) });
        }
    }
}
