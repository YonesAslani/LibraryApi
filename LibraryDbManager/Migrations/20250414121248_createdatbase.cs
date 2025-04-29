using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDbManager.Migrations
{
    /// <inheritdoc />
    public partial class createdatbase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookWriter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AdminTypes_AdminTypeId",
                        column: x => x.AdminTypeId,
                        principalTable: "AdminTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookCategoryRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookCategoryRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookCategoryRelations_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookCategoryRelations_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AdminTypeId",
                table: "Admins",
                column: "AdminTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookCategoryRelations_BookId",
                table: "bookCategoryRelations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookCategoryRelations_CategoryId",
                table: "bookCategoryRelations",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "bookCategoryRelations");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "AdminTypes");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
