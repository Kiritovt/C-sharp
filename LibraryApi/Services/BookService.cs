
using LibraryApi.Dtos;
using LibraryApi.Models;
using LibraryApi.Repositories;
namespace LibraryApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookrepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookrepository = bookRepository;
    }

    public List<Book> GetBooks(int? year)
    {
        List<Book> books = _bookrepository.GetAllBooks();
        if(year == null)
        {
            return books;
        }
        else
        {
            List<Book> filtered = books.Where(b => b.PublicationYear == year).ToList();
            return filtered;
        }
    }

    public Book? GetBookById(int id)
    {
        return _bookrepository.GetBookById(id);
    }

    public Book CreateBook(CreateBookDto bookDto)
    {
        Book book = new Book
        {
            Title = bookDto.Title,
            PublicationYear = bookDto.PublicationYear
        };
        _bookrepository.AddBook(book);
        return book;
    }

    public bool UpdateBook(int id, UpdateBookDto bookDto)
    {
        Book? book = _bookrepository.GetBookById(id);
        if (book != null)
        {
            book.Title = bookDto.Title;
            book.PublicationYear = bookDto.PublicationYear;
            return _bookrepository.UpdateBook(book);
        }
        else
        {
            return false;
        }
    }
    public bool DeleteBook(int id)
    {
           return _bookrepository.DeleteBook(id);
    }
}