using Microsoft.EntityFrameworkCore.Migrations;

namespace CityService.Migrations
{
    public partial class Seed2 : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "PostalCode", "Country", "StateCode" },
                values: new object[] { 1, "A", "AA", "AAA", "AAAA" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "PostalCode", "Country", "StateCode" },
                values: new object[] { 2, "BB", "B", "BBB", "BBBB" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "PostalCode", "Country", "StateCode" },
                values: new object[] { 3, "C", "CC", "CCC", "CCCC" });
        }
    }
}
