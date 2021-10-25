using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinfast.api.Migrations
{
    public partial class it : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "versions",
                columns: table => new
                {
                    VersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_versions", x => x.VersionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VersionId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "versions",
                        principalColumn: "VersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "PhotoPath", "Price", "VersionId" },
                values: new object[,]
                {
                    { 1, "LUX A2.0", "image/a20.png", 800000000L, null },
                    { 2, "LUX SA2.0", "image/sa20.png", 1200000000L, null },
                    { 3, "Fadil", "image/fadil.png", 362000000L, null },
                    { 4, "President", "image/president.png", 3800000000L, null }
                });

            migrationBuilder.InsertData(
                table: "versions",
                columns: new[] { "VersionId", "VersionName" },
                values: new object[,]
                {
                    { 1, "Tiêu Chuẩn" },
                    { 2, "Nâng Cao" },
                    { 3, "Cao Cấp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_VersionId",
                table: "Products",
                column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "versions");
        }
    }
}
