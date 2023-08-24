namespace BookShopApp.Controllers;

using BookShopApp.Data;
using BookShopApp.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BookDetailsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public BookDetailsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDetail>> GetByIdAsync(int id)
    {
        var bookDetails = await _db.BookDetails.FindAsync(id);

        if(bookDetails == null)
        {
            return NotFound();
        }

        return Ok(bookDetails);
    }

    //[HttpPost]
    //public async Task<ActionResult<BookDetail>> PostBookDetail(BookDetail bookDetail)
    //{
    //    if (bookDetail == null)
    //    {
    //        return BadRequest();
    //    }

    //    _db.BookDetails.Add(bookDetail);
    //    await _db.SaveChangesAsync();

    //    return CreatedAtAction(
    //        nameof(GetByIdAsync), 
    //        new { id = bookDetail.Id }, 
    //        bookDetail);
    //}
}
