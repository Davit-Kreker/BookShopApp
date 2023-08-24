namespace BookShopApp.Data;

using BookShopApp.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookDetail> BookDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// data seeding
        //modelBuilder.Entity<Book>().HasData(
        //    new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", Count = 57 },
        //    new Book { Id = 2, Title = "1984", Author = "George Orwell", Count = 20 },
        //    new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Count = 60 },
        //    new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Count = 37 },
        //    new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Count = 2 });

        //modelBuilder.Entity<BookDetail>().HasData(
        //    new BookDetail { Id = 1, Description = "Classic novel by Harper Lee.", BookId = 1 },
        //    new BookDetail { Id = 2, Description = "Dystopian masterpiece by George Orwell.", BookId = 2 },
        //    new BookDetail { Id = 3, Description = "F. Scott Fitzgerald's Jazz Age novel.", BookId = 3 },
        //    new BookDetail { Id = 4, Description = "Jane Austen's timeless love story.", BookId = 4 },
        //    new BookDetail { Id = 5, Description = "J.D. Salinger's coming-of-age classic.", BookId = 5 });
    }
}
