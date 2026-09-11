
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Services;

public class BookService : IBookService
{
    private List<Book> _bookList = new List<Book>()
    {
        new Book {Id=1, Title= "How I Met Your Mother?", PublicationYear= 1998},
        new Book{Id= 2, Title="Is this the truth?", PublicationYear=2012 }
    };

    public List<Book> GetBooks(int? year)
    {
        if (year == null)
        {
            return (_bookList);
        }
        else
        {
            List<Book> filtered = _bookList.Where(b => b.PublicationYear == year).ToList();
            return (filtered);
        }
    }

    public Book? GetBookById(int id)
    {
        Book? filtered = _bookList.FirstOrDefault(b => b.Id == id);
        if (filtered != null)
        {
            return filtered;
        }
        else
        {
            return null;
        }
    }

    public Book CreateBook(CreateBookDto bookDto)
    {
        Book book = new Book
        {
            Id = _bookList.Max(b => b.Id) + 1,
            Title = bookDto.Title,
            PublicationYear = bookDto.PublicationYear
        };

        _bookList.Add(book);
        return book;
    }

    public bool UpdateBook(int id, UpdateBookDto bookDto)
    {
        Book? filtered = _bookList.FirstOrDefault(bl => bl.Id == id);

        if (filtered != null)
        {
            filtered.Title = bookDto.Title;
            filtered.PublicationYear = bookDto.PublicationYear;
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool DeleteBook(int Id)
    {
        Book? filtered = _bookList.FirstOrDefault(b => b.Id == Id);

        if (filtered != null)
        {
            _bookList.Remove(filtered);
            return true;
        }
        else
        {
            return false;
        }
    }
}