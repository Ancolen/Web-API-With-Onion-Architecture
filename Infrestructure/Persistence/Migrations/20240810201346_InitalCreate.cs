using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueueID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(6009), false, "Beauty" },
                    { 2, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(6057), false, "Health, Grocery & Movies" },
                    { 3, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(6068), true, "Books & Garden" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedDate", "IsDeleted", "Name", "ParentID", "QueueID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(7407), false, "Electronic", 0, 1 },
                    { 2, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(7409), false, "House & Life", 0, 2 },
                    { 3, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(7410), false, "Computer", 1, 1 },
                    { 4, new DateTime(2024, 8, 10, 23, 13, 46, 388, DateTimeKind.Local).AddTicks(7411), false, "Furniture", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 10, 23, 13, 46, 390, DateTimeKind.Local).AddTicks(7181), "Lambadaki exercitationem gazete.", false, "Quis." },
                    { 2, 3, new DateTime(2024, 8, 10, 23, 13, 46, 390, DateTimeKind.Local).AddTicks(7213), "Sıradanlıktan voluptatem dağılımı.", false, "Nihil koyun." },
                    { 3, 4, new DateTime(2024, 8, 10, 23, 13, 46, 390, DateTimeKind.Local).AddTicks(7243), "Modi voluptatem nisi.", true, "Tempora anlamsız ut." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "BrandID", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 10, 23, 13, 46, 393, DateTimeKind.Local).AddTicks(6653), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 0.506599704379120m, false, 963.38m, "Rustic Frozen Car" },
                    { 2, 3, new DateTime(2024, 8, 10, 23, 13, 46, 393, DateTimeKind.Local).AddTicks(6676), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 1.184243413693090m, false, 353.63m, "Fantastic Metal Shoes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsID",
                table: "CategoryProduct",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryID",
                table: "Details",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
