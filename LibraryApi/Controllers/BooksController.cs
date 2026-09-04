using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using Microsoft.AspNetCore.Components.Routing;

namespace LibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BooksController : ControllerBase
{

    private static List<Book> BookList = new List<Book>
    {
        new Book {Id=1, Title= "How I Met Your Mother?", PublicationYear= 1998},
        new Book{Id= 2, Title="Is this the truth?", PublicationYear=2012 }
    };
    [HttpGet]

    public ActionResult<List<Book>> GetBooks()
    {
        return Ok(BookList);
    }

    [HttpGet("{id}")]

    public ActionResult<Book> GetBook(int id)
    {
        Book? filtered = BookList.FirstOrDefault(b => b.Id == id);

        if (filtered != null)
        {
            return Ok(filtered);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] Book book)
    {
        BookList.Add(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook([FromRoute] int id, [FromBody] Book book)
    {
        Book? filtered = BookList.FirstOrDefault(bl => bl.Id == id);

        if (filtered != null)
        {
            filtered.Title = book.Title;
            filtered.PublicationYear = book.PublicationYear;
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        Book? filtered = BookList.FirstOrDefault(bl => bl.Id == id);
        if(filtered != null)
        {
            BookList.Remove(filtered);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}

