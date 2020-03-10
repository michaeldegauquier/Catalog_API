using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Price_Currency = table.Column<string>(nullable: true),
                    Price_Value = table.Column<float>(nullable: false),
                    Price_Formatted = table.Column<string>(nullable: true),
                    OriginalPrice_Currency = table.Column<string>(nullable: true),
                    OriginalPrice_Value = table.Column<float>(nullable: false),
                    OriginalPrice_Formatted = table.Column<string>(nullable: true),
                    Available = table.Column<bool>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ProductId",
                table: "Unit",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
