using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.API.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrandKey",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brandfamily",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShopUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brandfamily", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    LogoLargeUrl = table.Column<string>(nullable: true),
                    BrandfamilyKey = table.Column<string>(nullable: true),
                    ShopUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Brand_Brandfamily_BrandfamilyKey",
                        column: x => x.BrandfamilyKey,
                        principalTable: "Brandfamily",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandKey",
                table: "Product",
                column: "BrandKey");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_BrandfamilyKey",
                table: "Brand",
                column: "BrandfamilyKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandKey",
                table: "Product",
                column: "BrandKey",
                principalTable: "Brand",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandKey",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Brandfamily");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandKey",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandKey",
                table: "Product");
        }
    }
}
