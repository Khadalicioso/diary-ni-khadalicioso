using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace diary_webapp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 12, 16, 42, 687, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[] { 2, "I have been playing games since 2012", new DateTime(2024, 12, 28, 12, 16, 42, 687, DateTimeKind.Local).AddTicks(693), "Gaming 24/7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 12, 28, 12, 11, 24, 121, DateTimeKind.Local).AddTicks(9066));
        }
    }
}
