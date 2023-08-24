namespace BookShopApp.Controllers;

using BookShopApp.Data;
using BookShopApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public BooksController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("All")]
    //public async Task<IActionResult> GetAllAsync()
    public async Task<ActionResult<IEnumerable<Book>>> GetAllAsync()
    {
        //var books = await _db.Books.ToListAsync();
        //return Ok(books);
        Console.WriteLine("Hello");

        return Ok(await _db.Books.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Book>> GetByIdAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpGet("Name/{title}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetByTitleAsync(string title)
    {
        //return Ok(await _db.Books.Where(b => b.Title.Contains(title)).ToListAsync());

        var book = await _db.Books
            .Where(b => b.Title.Contains(title))
            .ToListAsync();

        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }


    //[HttpPost("Create")]
    //public async Task<ActionResult<Book>> CreateAsync(Book book)
    //{
    //    if (book == null)
    //    {
    //        return BadRequest();
    //    }

    //    _db.Books.Add(book);
    //    await _db.SaveChangesAsync();

    //    return CreatedAtRoute(nameof(GetByIdAsync), new { id = book.Id }, book);
    //    //return Ok(book);
    //}

    [HttpPost("Create")]
    public async Task<ActionResult<Book>> CreateAsync(Book book)
    {
        if (book == null)
        {
            return BadRequest();
        }

        var bookDetail = new BookDetail
        {
            Description = book.BookDetail.Description
        };

        book.BookDetail = bookDetail;

        _db.Books.Add(book);
        await _db.SaveChangesAsync();

        return CreatedAtRoute(nameof(GetByIdAsync), new { id = book.Id }, book);
    }

    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Book updatedBook)
    {
        if (id != updatedBook.Id)
        {
            return BadRequest();
        }

        var existingBook = await _db.Books.FindAsync(id);

        if (existingBook == null)
        {
            return NotFound();
        }

        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.Count = updatedBook.Count;

        //_db.Entry(existingBook).State = EntityState.Modified;
        _db.Books.Update(existingBook);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("PartialUpdate{id:int}")]
    public async Task<IActionResult> PartialUpdateAsync(int id, JsonPatchDocument<Book> patchDoc)
    {
        var existingBook = await _db.Books.FindAsync(id);

        if (existingBook == null)
        {
            return NotFound();
        }

        patchDoc.ApplyTo(existingBook, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //_db.Entry(existingBook).State = EntityState.Modified;
        _db.Books.Update(existingBook);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _db.Books.Remove(book);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
