using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Dtos;

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

    public ActionResult<List<Book>> GetBooks([FromQuery]int? year)
    {
        if(year != null)
        {
            List<Book> filtered = BookList.Where(b => b.PublicationYear == year).ToList();
            return Ok(filtered);
        } else
        {
            return Ok(BookList);
        }
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
    public ActionResult<Book> CreateBook([FromBody] CreateBookDto bookDto)
    {
        Book book = new Book
        {
            Id = BookList.Max(b=>b.Id) + 1,
            Title = bookDto.Title,
            PublicationYear = bookDto.PublicationYear
        };
        
        BookList.Add(book);
        return CreatedAtAction( nameof(GetBook), new { id = book.Id}, book );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
    {
        Book? filtered = BookList.FirstOrDefault(bl => bl.Id == id);

        if (filtered != null)
        {
            filtered.Title = bookDto.Title;
            filtered.PublicationYear = bookDto.PublicationYear;
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

