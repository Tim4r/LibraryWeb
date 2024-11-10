using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TakenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLoans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_Id",
                        column: x => x.Id,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "User", "USER" },
                    { 2, null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9f357a2fe789", "Qwerty123@mail.ru", false, false, null, "QWERTY123@MAIL.RU", "DENIS", "AQAAAAIAAYagAAAAENe3wvuT2R5/bFGwydlEL6Elft/pTEWWVML4K+NyHjvGUGkiigJ3CkxPsVKuzYlnPA==", "", null, false, "KEMVD7XCEIMTZXEA7C6PDNMO5OCQD5IG", false, "Denis" },
                    { 2, 0, "47c4cabf-3db5-46c5-bcfc-7724c0cb761d", "Qwerty123@mail.ru", false, false, null, "QWERTY123@MAIL.RU", "ANTON", "AQAAAAIAAYagAAAAEFAm4UHPiz3NH8XJlo8evnNVjCs+1BLQH0KEx7RckQGTscIwUiD0hdRu8l1yfR5TyQ==", "", null, false, "OLNIUQ7NTGS6D74TXCHQTKIAAKX4U3PU", false, "Anton" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthDate", "Country", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "J.K.", "Rowling" },
                    { 2, new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "George R.R.", "Martin" },
                    { 3, new DateTime(1953, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Stephen", "King" },
                    { 4, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "J.R.R.", "Tolkien" },
                    { 5, new DateTime(1926, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Harper", "Lee" },
                    { 6, new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Jane", "Austen" },
                    { 7, new DateTime(1812, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Charles", "Dickens" },
                    { 8, new DateTime(1828, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russia", "Leo", "Tolstoy" },
                    { 9, new DateTime(1882, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Virginia", "Woolf" },
                    { 10, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada", "Gabriel", "Ansley" },
                    { 11, new DateTime(1975, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Zadie", "Smith" },
                    { 12, new DateTime(1936, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Don", "DeLillo" },
                    { 13, new DateTime(1939, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada", "Margaret", "Atwood" },
                    { 14, new DateTime(1954, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan/United Kingdom", "Kazuo", "Ishiguro" },
                    { 15, new DateTime(1931, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada", "Alice", "Munro" },
                    { 16, new DateTime(1947, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "India/United Kingdom", "Salman", "Rushdie" },
                    { 17, new DateTime(1952, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkey", "Orhan", "Pamuk" },
                    { 18, new DateTime(1938, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya", "Ngugi wa", "Thiong o" },
                    { 19, new DateTime(1899, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemala", "Miguel Angel", "Asturias" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Literary Fiction" },
                    { 4, "Historical Fiction" },
                    { 5, "Horror" },
                    { 6, "Romantic Comedy" },
                    { 7, "Crime Fiction" },
                    { 8, "Philosophical Fiction" },
                    { 9, "Magical Realism" },
                    { 10, "Postmodern Literature" },
                    { 11, "Epistolary Novel" },
                    { 12, "Cyberpunk" },
                    { 13, "Surrealist Fiction" },
                    { 14, "Environmental Fiction" },
                    { 15, "Absurdism" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "GenreId", "ISBN", "Image", "Title" },
                values: new object[,]
                {
                    { 1, 1, "The first book in J.K. Rowling's beloved Harry Potter series.", 1, "9780747532699", null, "Harry Potter and the Philosopher's Stone" },
                    { 2, 2, "The first book in George R.R. Martin's A Song of Ice and Fire series.", 1, "9780553573404", null, "A Game of Thrones" },
                    { 3, 3, "A psychological horror novel by Stephen King about a writer held captive by his 'number one fan'.", 5, "9780743454651", null, "Misery" },
                    { 4, 4, "High fantasy adventure novel by J.R.R. Tolkien.", 1, "9780261103301", null, "The Lord of the Rings" },
                    { 5, 5, "Classic novel exploring racial injustice through the eyes of a young girl in the Deep South.", 2, "9780061120084", null, "To Kill a Mockingbird" },
                    { 6, 6, "Romantic novel of manners by Jane Austen.", 2, "9780743273565", null, "Pride and Prejudice" },
                    { 7, 7, "Classic Victorian-era novel about a poor orphan who falls in with a gang of pickpockets in London.", 3, "9780743274562", null, "Oliver Twist" },
                    { 8, 8, "Epic historical novel by Leo Tolstoy set during the Napoleonic Wars.", 3, "9780743273565", null, "War and Peace" },
                    { 9, 9, "Modernist novel by Virginia Woolf exploring life in post-World War I England.", 2, "9780241954719", null, "Mrs Dalloway" },
                    { 10, 10, "Modern magical realist novel by Gabriel Ansley about Dominican-American identity.", 6, "9780374158177", null, "The Brief Wondrous Life of Oscar Wao" },
                    { 11, 11, "Satirical novel by Zadie Smith exploring multiculturalism in post-war London.", 2, "9780312421135", null, "White Teeth" },
                    { 12, 12, "Postmodern epic novel by Don DeLillo spanning several decades of American history.", 4, "9780679767877", null, "Underworld" },
                    { 13, 13, "Dystopian novel by Margaret Atwood exploring a patriarchal society.", 1, "9780553283685", null, "The Handmaid's Tale" },
                    { 14, 14, "Haunting novel by Kazuo Ishiguro exploring the lives of three friends at an English boarding school.", 2, "9780099500736", null, "Never Let Me Go" },
                    { 15, 1, "Sixth book in the Harry Potter series by J.K. Rowling.", 1, "9780439708180", null, "Half-Blood Prince" },
                    { 16, 15, "Novel by Arundhati Roy exploring the intertwined lives of twins growing up in Kerala, India.", 2, "9781782115514", null, "The God of Small Things" },
                    { 17, 16, "Novel by Jhumpa Lahiri exploring the experiences of Indian immigrants in New York City.", 2, "9781400033416", null, "The Namesake" },
                    { 18, 17, "Haunting novel by Toni Morrison exploring the legacy of slavery and its effects on African Americans.", 5, "9780743273565", null, "Beloved" },
                    { 19, 18, "Novel by Khaled Hosseini exploring friendship, betrayal, and redemption in Afghanistan.", 2, "9780747584585", null, "The Kite Runner" },
                    { 20, 19, "Post-apocalyptic novel by Cormac McCarthy exploring a father-son journey through a devastated America.", 4, "9780307276750", null, "The Road" },
                    { 21, 14, "Novel by Kazuo Ishiguro exploring the life of a butler reflecting on his decades-long service at an English estate.", 2, "9780399159926", null, "The Remains of the Day" },
                    { 22, 19, "Novel by Kevin Brockmeier exploring an afterlife where souls exist in a vast library.", 4, "9781594200705", null, "The Brief History of the Dead" }
                });

            migrationBuilder.InsertData(
                table: "BookLoans",
                columns: new[] { "Id", "BookId", "ReturnTime", "TakenTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 4, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 6, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 8, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 9, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 10, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_UserId",
                table: "BookLoans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
