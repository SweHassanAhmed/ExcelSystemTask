using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class testChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 6, 21, 13, 24, 45, 92, DateTimeKind.Local).AddTicks(3740), new DateTime(2019, 6, 21, 13, 24, 45, 92, DateTimeKind.Local).AddTicks(9236) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModificationDate" },
                values: new object[] { new DateTime(2019, 6, 21, 10, 39, 50, 229, DateTimeKind.Local).AddTicks(5505), new DateTime(2019, 6, 21, 10, 39, 50, 230, DateTimeKind.Local).AddTicks(813) });
        }
    }
}
