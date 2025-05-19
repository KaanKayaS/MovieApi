using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(606), "Matthew McConaughey" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(611), "Jessica Chastain" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreatedDate", "FullName", "Image", "IsDeleted" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(613), "Harold Perrineau Jr.", "aa", false },
                    { 4, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(614), "Scott McCord", "aa", false }
                });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 19, 13, 7, 31, 425, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[] { 2, new DateTime(2025, 5, 19, 13, 7, 31, 425, DateTimeKind.Local).AddTicks(2330), false, "ABD" });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "CreatedDate", "FullName", "IsDeleted" },
                values: new object[] { 2, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(3886), "Jack Bender", false });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5208), false, "Aile" },
                    { 4, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5209), false, "Bilim Kurgu" },
                    { 5, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5210), false, "Aksiyon" },
                    { 6, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5212), false, "Macera" },
                    { 7, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(5213), false, "Komedi" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CountryId", "CreatedDate", "Duration", "ImdbPoint", "IsSubtitle", "IsTrDubbing", "MoviePlot", "PublicationDate" },
                values: new object[] { 2, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(6607), new TimeSpan(0, 2, 49, 0, 0), 8.6999999999999993, true, true, "Filmin odaklandığı yakın gelecekte yeryüzündeki yaşam; artan kuraklık ve iklim değişiklikleri nedeniyle tehlikeye girmiştir. İnsan ırkı yok olma tehlikesiyle karşı karşıyadır. Bu sırada yeni keşfedilen bir solucan deliği, tüm insanlığın umudu hâline gelir. Bir grup astronot-kaşif, buradan geçip boyut değiştirerek daha önce hiçbir insanoğlunun erişemediği yerlere ulaşmak ve insanoğlunun yeni yaşam alanlarını araştırmakla görevlendirilir. Bu kaşifler, geçen 1 saatin dünyadaki 7 yıla bedel olduğu bir ortamda hızlı ve cesur davranmak zorundadır.", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DirectorId", "Image", "ImdbPoint", "IsDeleted", "IsSubtitle", "IsTrDubbing", "Name", "PublicationDate", "SeasonCount", "SeriesPlot" },
                values: new object[] { 1, 2, new DateTime(2025, 5, 19, 10, 7, 31, 425, DateTimeKind.Utc).AddTicks(8757), 2, "aaa", 7.7999999999999998, false, true, true, "From", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), 3, "İsteksiz sakinler, normallik duygusunu sürdürmek ve bir çıkış yolu aramak için savaşırken, aynı zamanda, güneş battığında ortaya çıkan korkunç yaratıklar da dahil olmak üzere, çevredeki ormanın tehditlerine karşı da hayatta kalmak zorundadırlar." });

            migrationBuilder.InsertData(
                table: "ActorSeries",
                columns: new[] { "ActorsId", "SeriesId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "GenreSeries",
                columns: new[] { "GenresId", "SeriesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorSeries",
                keyColumns: new[] { "ActorsId", "SeriesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ActorSeries",
                keyColumns: new[] { "ActorsId", "SeriesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresId", "MoviesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "GenreSeries",
                keyColumns: new[] { "GenresId", "SeriesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreSeries",
                keyColumns: new[] { "GenresId", "SeriesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GenreSeries",
                keyColumns: new[] { "GenresId", "SeriesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(7231), "John Smith" });

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "FullName" },
                values: new object[] { new DateTime(2025, 5, 16, 19, 58, 53, 633, DateTimeKind.Local).AddTicks(7234), "Emily Blunt" });

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

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

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
                columns: new[] { "CountryId", "CreatedDate", "Duration", "ImdbPoint", "IsSubtitle", "IsTrDubbing", "MoviePlot", "PublicationDate" },
                values: new object[] { 1, new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(1154), new TimeSpan(0, 2, 30, 0, 0), 9.5, false, false, "gerilim dolu bir kovalamaca", new DateTime(2025, 5, 16, 19, 58, 53, 634, DateTimeKind.Local).AddTicks(1147) });
        }
    }
}
