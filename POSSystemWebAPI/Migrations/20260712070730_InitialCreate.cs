using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace POSSystemWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item_Category",
                columns: table => new
                {
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Category", x => x.ItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Location_Details",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Details", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_Item",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    StandardCost = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    StandardPrice = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    Margin = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    FreeQuantity = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    Discount = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    TotalSelling = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Item", x => x.Item_Id);
                    table.ForeignKey(
                        name: "FK_Order_Item_Item_Category_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "Item_Category",
                        principalColumn: "ItemCategoryId");
                    table.ForeignKey(
                        name: "FK_Order_Item_Location_Details_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location_Details",
                        principalColumn: "Location_Id");
                });

            migrationBuilder.InsertData(
                table: "Item_Category",
                columns: new[] { "ItemCategoryId", "CreatedBy", "CreatedDate", "IsActive", "Item", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, null, true, "Mango", null, null },
                    { 2, null, null, true, "Apple", null, null },
                    { 3, null, null, true, "Banana", null, null },
                    { 4, null, null, true, "Orange", null, null },
                    { 5, null, null, true, "Grapes", null, null },
                    { 6, null, null, true, "Kiwi", null, null },
                    { 7, null, null, true, "Strawberry", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_Details_Location_Code",
                table: "Location_Details",
                column: "Location_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Item_ItemCategoryId",
                table: "Order_Item",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Item_LocationId",
                table: "Order_Item",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Item");

            migrationBuilder.DropTable(
                name: "Item_Category");

            migrationBuilder.DropTable(
                name: "Location_Details");
        }
    }
}
