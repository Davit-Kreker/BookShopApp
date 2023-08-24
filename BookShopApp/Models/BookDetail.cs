namespace BookShopApp.Models;

public class BookDetail
{
    public int Id { get; set; }
    public string Description { get; set; }

    // Foreign key
    public int BookId { get; set; }
    // navigation properties
    public Book Book { get; set; }
}