using Library.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Context;

public class ApplicationDBContext : IdentityDbContext<User, Role, int>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.BookLoan)
            .WithOne(bl => bl.Book) 
            .HasForeignKey<BookLoan>(bl => bl.BookId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling", BirthDate = new DateTime(1965, 7, 31), Country = "United Kingdom" },
            new Author { Id = 2, FirstName = "George R.R.", LastName = "Martin", BirthDate = new DateTime(1948, 9, 20), Country = "United States" },
            new Author { Id = 3, FirstName = "Stephen", LastName = "King", BirthDate = new DateTime(1953, 9, 21), Country = "United States" },
            new Author { Id = 4, FirstName = "J.R.R.", LastName = "Tolkien", BirthDate = new DateTime(1892, 1, 3), Country = "United Kingdom" },
            new Author { Id = 5, FirstName = "Harper", LastName = "Lee", BirthDate = new DateTime(1926, 4, 28), Country = "United States" },
            new Author { Id = 6, FirstName = "Jane", LastName = "Austen", BirthDate = new DateTime(1775, 12, 16), Country = "England" },
            new Author { Id = 7, FirstName = "Charles", LastName = "Dickens", BirthDate = new DateTime(1812, 2, 7), Country = "England" },
            new Author { Id = 8, FirstName = "Leo", LastName = "Tolstoy", BirthDate = new DateTime(1828, 8, 9), Country = "Russia" },
            new Author { Id = 9, FirstName = "Virginia", LastName = "Woolf", BirthDate = new DateTime(1882, 1, 25), Country = "England" },
            new Author { Id = 10, FirstName = "Gabriel", LastName = "Ansley", BirthDate = new DateTime(1990, 5, 15), Country = "Canada" },
            new Author { Id = 11, FirstName = "Zadie", LastName = "Smith", BirthDate = new DateTime(1975, 10, 25), Country = "United Kingdom" },
            new Author { Id = 12, FirstName = "Don", LastName = "DeLillo", BirthDate = new DateTime(1936, 11, 20), Country = "United States" },
            new Author { Id = 13, FirstName = "Margaret", LastName = "Atwood", BirthDate = new DateTime(1939, 11, 18), Country = "Canada" },
            new Author { Id = 14, FirstName = "Kazuo", LastName = "Ishiguro", BirthDate = new DateTime(1954, 11, 8), Country = "Japan/United Kingdom" },
            new Author { Id = 15, FirstName = "Alice", LastName = "Munro", BirthDate = new DateTime(1931, 7, 10), Country = "Canada" },
            new Author { Id = 16, FirstName = "Salman", LastName = "Rushdie", BirthDate = new DateTime(1947, 6, 19), Country = "India/United Kingdom" },
            new Author { Id = 17, FirstName = "Orhan", LastName = "Pamuk", BirthDate = new DateTime(1952, 6, 13), Country = "Turkey" },
            new Author { Id = 18, FirstName = "Ngugi wa", LastName = "Thiong o", BirthDate = new DateTime(1938, 1, 5), Country = "Kenya" },
            new Author { Id = 19, FirstName = "Miguel Angel", LastName = "Asturias", BirthDate = new DateTime(1899, 10, 19), Country = "Guatemala" }
        );

        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Fantasy" },
            new Genre { Id = 2, Name = "Science Fiction" },
            new Genre { Id = 3, Name = "Literary Fiction" },
            new Genre { Id = 4, Name = "Historical Fiction" },
            new Genre { Id = 5, Name = "Horror" },
            new Genre { Id = 6, Name = "Romantic Comedy" },
            new Genre { Id = 7, Name = "Crime Fiction" },
            new Genre { Id = 8, Name = "Philosophical Fiction" },
            new Genre { Id = 9, Name = "Magical Realism" },
            new Genre { Id = 10, Name = "Postmodern Literature" },
            new Genre { Id = 11, Name = "Epistolary Novel" },
            new Genre { Id = 12, Name = "Cyberpunk" },
            new Genre { Id = 13, Name = "Surrealist Fiction" },
            new Genre { Id = 14, Name = "Environmental Fiction" },
            new Genre { Id = 15, Name = "Absurdism" }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", ISBN = "9780747532699", Description = "The first book in J.K. Rowling's beloved Harry Potter series.", Image = null, AuthorId = 1, GenreId = 1 },
            new Book { Id = 2, Title = "A Game of Thrones", ISBN = "9780553573404", Description = "The first book in George R.R. Martin's A Song of Ice and Fire series.", Image = null, AuthorId = 2, GenreId = 1 },
            new Book { Id = 3, Title = "Misery", ISBN = "9780743454651", Description = "A psychological horror novel by Stephen King about a writer held captive by his 'number one fan'.", Image = null, AuthorId = 3, GenreId = 5 },
            new Book { Id = 4, Title = "The Lord of the Rings", ISBN = "9780261103301", Description = "High fantasy adventure novel by J.R.R. Tolkien.", Image = null, AuthorId = 4, GenreId = 1 },
            new Book { Id = 5, Title = "To Kill a Mockingbird", ISBN = "9780061120084", Description = "Classic novel exploring racial injustice through the eyes of a young girl in the Deep South.", Image = null, AuthorId = 5, GenreId = 2 },
            new Book { Id = 6, Title = "Pride and Prejudice", ISBN = "9780743273565", Description = "Romantic novel of manners by Jane Austen.", Image = null, AuthorId = 6, GenreId = 2 },
            new Book { Id = 7, Title = "Oliver Twist", ISBN = "9780743274562", Description = "Classic Victorian-era novel about a poor orphan who falls in with a gang of pickpockets in London.", Image = null, AuthorId = 7, GenreId = 3 },
            new Book { Id = 8, Title = "War and Peace", ISBN = "9780743273565", Description = "Epic historical novel by Leo Tolstoy set during the Napoleonic Wars.", Image = null, AuthorId = 8, GenreId = 3 },
            new Book { Id = 9, Title = "Mrs Dalloway", ISBN = "9780241954719", Description = "Modernist novel by Virginia Woolf exploring life in post-World War I England.", Image = null, AuthorId = 9, GenreId = 2 },
            new Book { Id = 10, Title = "The Brief Wondrous Life of Oscar Wao", ISBN = "9780374158177", Description = "Modern magical realist novel by Gabriel Ansley about Dominican-American identity.", Image = null, AuthorId = 10, GenreId = 6 },
            new Book { Id = 11, Title = "White Teeth", ISBN = "9780312421135", Description = "Satirical novel by Zadie Smith exploring multiculturalism in post-war London.", Image = null, AuthorId = 11, GenreId = 2 },
            new Book { Id = 12, Title = "Underworld", ISBN = "9780679767877", Description = "Postmodern epic novel by Don DeLillo spanning several decades of American history.", Image = null, AuthorId = 12, GenreId = 4 },
            new Book { Id = 13, Title = "The Handmaid's Tale", ISBN = "9780553283685", Description = "Dystopian novel by Margaret Atwood exploring a patriarchal society.", Image = null, AuthorId = 13, GenreId = 1 },
            new Book { Id = 14, Title = "Never Let Me Go", ISBN = "9780099500736", Description = "Haunting novel by Kazuo Ishiguro exploring the lives of three friends at an English boarding school.", Image = null, AuthorId = 14, GenreId = 2 },
            new Book { Id = 15, Title = "Half-Blood Prince", ISBN = "9780439708180", Description = "Sixth book in the Harry Potter series by J.K. Rowling.", Image = null, AuthorId = 1, GenreId = 1 },
            new Book { Id = 16, Title = "The God of Small Things", ISBN = "9781782115514", Description = "Novel by Arundhati Roy exploring the intertwined lives of twins growing up in Kerala, India.", Image = null, AuthorId = 15, GenreId = 2 },
            new Book { Id = 17, Title = "The Namesake", ISBN = "9781400033416", Description = "Novel by Jhumpa Lahiri exploring the experiences of Indian immigrants in New York City.", Image = null, AuthorId = 16, GenreId = 2 },
            new Book { Id = 18, Title = "Beloved", ISBN = "9780743273565", Description = "Haunting novel by Toni Morrison exploring the legacy of slavery and its effects on African Americans.", Image = null, AuthorId = 17, GenreId = 5 },
            new Book { Id = 19, Title = "The Kite Runner", ISBN = "9780747584585", Description = "Novel by Khaled Hosseini exploring friendship, betrayal, and redemption in Afghanistan.", Image = null, AuthorId = 18, GenreId = 2 },
            new Book { Id = 20, Title = "The Road", ISBN = "9780307276750", Description = "Post-apocalyptic novel by Cormac McCarthy exploring a father-son journey through a devastated America.", Image = null, AuthorId = 19, GenreId = 4 },
            new Book { Id = 21, Title = "The Remains of the Day", ISBN = "9780399159926", Description = "Novel by Kazuo Ishiguro exploring the life of a butler reflecting on his decades-long service at an English estate.", Image = null, AuthorId = 14, GenreId = 2 },
            new Book { Id = 22, Title = "The Brief History of the Dead", ISBN = "9781594200705", Description = "Novel by Kevin Brockmeier exploring an afterlife where souls exist in a vast library.", Image = null, AuthorId = 19, GenreId = 4 }
        );

        var user1 = new User
        {
            Id = 1,
            UserName = "Denis",
            NormalizedUserName = "DENIS",
            Email = "Qwerty123@mail.ru",
            NormalizedEmail = "QWERTY123@MAIL.RU",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAIAAYagAAAAENe3wvuT2R5/bFGwydlEL6Elft/pTEWWVML4K+NyHjvGUGkiigJ3CkxPsVKuzYlnPA==",
            SecurityStamp = "KEMVD7XCEIMTZXEA7C6PDNMO5OCQD5IG",
            ConcurrencyStamp = "9f357a2fe789"
        };
        var user2 = new User
        {
            Id = 2,
            UserName = "Anton",
            NormalizedUserName = "ANTON",
            Email = "Qwerty1234@mail.ru",
            NormalizedEmail = "QWERTY123@MAIL.RU",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAIAAYagAAAAEFAm4UHPiz3NH8XJlo8evnNVjCs+1BLQH0KEx7RckQGTscIwUiD0hdRu8l1yfR5TyQ==",
            SecurityStamp = "OLNIUQ7NTGS6D74TXCHQTKIAAKX4U3PU",
            ConcurrencyStamp = "47c4cabf-3db5-46c5-bcfc-7724c0cb761d"
        };
        modelBuilder.Entity<User>().HasData(user1, user2);

        modelBuilder.Entity<Role>().HasData(
            new IdentityRole<int> { Id = 1, Name = "User", NormalizedName = "USER" },
            new IdentityRole<int> { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
        );

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
            new IdentityUserRole<int> { UserId = 2, RoleId = 2 }
        );

        modelBuilder.Entity<BookLoan>().HasData(
            new BookLoan { Id = 1, TakenTime = new DateTime(2023, 1, 1), ReturnTime = new DateTime(2023, 1, 15), UserId = 1, BookId = 1 },
            new BookLoan { Id = 2, TakenTime = new DateTime(2023, 1, 2), ReturnTime = new DateTime(2023, 1, 16), UserId = 2, BookId = 2 },
            new BookLoan { Id = 3, TakenTime = new DateTime(2023, 1, 3), ReturnTime = new DateTime(2023, 1, 17), UserId = 1, BookId = 3 },
            new BookLoan { Id = 4, TakenTime = new DateTime(2023, 1, 4), ReturnTime = new DateTime(2023, 1, 18), UserId = 2, BookId = 4 },
            new BookLoan { Id = 5, TakenTime = new DateTime(2023, 1, 5), ReturnTime = new DateTime(2023, 1, 19), UserId = 1, BookId = 5 },
            new BookLoan { Id = 6, TakenTime = new DateTime(2023, 1, 6), ReturnTime = new DateTime(2023, 1, 20), UserId = 2, BookId = 6 },
            new BookLoan { Id = 7, TakenTime = new DateTime(2023, 1, 7), ReturnTime = new DateTime(2023, 1, 21), UserId = 1, BookId = 7 },
            new BookLoan { Id = 8, TakenTime = new DateTime(2023, 1, 8), ReturnTime = new DateTime(2023, 1, 22), UserId = 2, BookId = 8 },
            new BookLoan { Id = 9, TakenTime = new DateTime(2023, 1, 9), ReturnTime = new DateTime(2023, 1, 23), UserId = 1, BookId = 9 },
            new BookLoan { Id = 10, TakenTime = new DateTime(2023, 1, 10), ReturnTime = new DateTime(2023, 1, 24), UserId = 2, BookId = 10 }
        );
    }
}

