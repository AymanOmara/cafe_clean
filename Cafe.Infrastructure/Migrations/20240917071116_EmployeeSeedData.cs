using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cafe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 2, "Ayman $1", "01029045270$1" },
                    { 2, 4, "Ayman $2", "01029045270$2" },
                    { 3, 6, "Ayman $3", "01029045270$3" },
                    { 4, 8, "Ayman $4", "01029045270$4" },
                    { 5, 10, "Ayman $5", "01029045270$5" },
                    { 6, 12, "Ayman $6", "01029045270$6" },
                    { 7, 14, "Ayman $7", "01029045270$7" },
                    { 8, 16, "Ayman $8", "01029045270$8" },
                    { 9, 18, "Ayman $9", "01029045270$9" },
                    { 10, 20, "Ayman $10", "01029045270$10" },
                    { 11, 22, "Ayman $11", "01029045270$11" },
                    { 12, 24, "Ayman $12", "01029045270$12" },
                    { 13, 26, "Ayman $13", "01029045270$13" },
                    { 14, 28, "Ayman $14", "01029045270$14" },
                    { 15, 30, "Ayman $15", "01029045270$15" },
                    { 16, 32, "Ayman $16", "01029045270$16" },
                    { 17, 34, "Ayman $17", "01029045270$17" },
                    { 18, 36, "Ayman $18", "01029045270$18" },
                    { 19, 38, "Ayman $19", "01029045270$19" },
                    { 20, 40, "Ayman $20", "01029045270$20" },
                    { 21, 42, "Ayman $21", "01029045270$21" },
                    { 22, 44, "Ayman $22", "01029045270$22" },
                    { 23, 46, "Ayman $23", "01029045270$23" },
                    { 24, 48, "Ayman $24", "01029045270$24" },
                    { 25, 50, "Ayman $25", "01029045270$25" },
                    { 26, 52, "Ayman $26", "01029045270$26" },
                    { 27, 54, "Ayman $27", "01029045270$27" },
                    { 28, 56, "Ayman $28", "01029045270$28" },
                    { 29, 58, "Ayman $29", "01029045270$29" },
                    { 30, 60, "Ayman $30", "01029045270$30" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
