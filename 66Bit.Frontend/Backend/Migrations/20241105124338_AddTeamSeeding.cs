using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12907856-eb9f-455e-8cd0-b3712609a076"), "Барселона" },
                    { new Guid("d43096e6-cd77-470c-959d-467bf15d7dba"), "Реал Мадрид" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("12907856-eb9f-455e-8cd0-b3712609a076"));

            migrationBuilder.DeleteData(
                table: "teams",
                keyColumn: "Id",
                keyValue: new Guid("d43096e6-cd77-470c-959d-467bf15d7dba"));
        }
    }
}
