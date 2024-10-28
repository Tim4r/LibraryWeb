using Library.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Context;

public class ApplicationDBContext : IdentityDbContext<User, Role, int>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.BookLoan)
            .WithOne(bl => bl.Book)
            .HasForeignKey<BookLoan>(bl => bl.BookId);

        base.OnModelCreating(modelBuilder);
    }
}

