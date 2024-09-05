using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "BatchNo", "BatchQty", "Date", "DyeingProcess", "FType", "MCNo", "Remarks", "WorkOrderNo", "YarnLotNo" },
                values: new object[,]
                {
                    { 1, "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat" },
                    { 2, "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat", "Rafat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
