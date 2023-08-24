using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookShopApp.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Count { get; set; }

    // Navigation property
    public BookDetail BookDetail { get; set; }
}
