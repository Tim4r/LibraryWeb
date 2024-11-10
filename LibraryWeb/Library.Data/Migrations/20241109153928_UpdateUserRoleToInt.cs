using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoleToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookLoans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
