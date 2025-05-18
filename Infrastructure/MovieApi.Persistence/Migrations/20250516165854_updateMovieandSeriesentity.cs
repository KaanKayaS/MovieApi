using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateMovieandSeriesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesImdbs");

            migrationBuilder.AddColumn<double>(
                name: "ImdbPoint",
                table: "Series",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubtitle",
                table: "Series",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrDubbing",
                table: "Series",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubtitle",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrDubbing",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(9387));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsSubtitle", "IsTrDubbing", "PublicationDate" },
                values: new object[] { new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(1154), false, false, new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(1147) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImdbPoint",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "IsSubtitle",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "IsTrDubbing",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "IsSubtitle",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsTrDubbing",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "SeriesImdbs",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImdbPoint = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesImdbs", x => new { x.SeriesId, x.Season });
                    table.ForeignKey(
                        name: "FK_SeriesImdbs_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
    }
}
