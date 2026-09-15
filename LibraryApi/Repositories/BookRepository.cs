
using LibraryApi.Data;
using LibraryApi.Models;
namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public Book? GetBookById(int id)
    {
        Book? bookFound = _context.Books.FirstOrDefault(b=> b.Id == id);
        return bookFound;
    }

    public void AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public bool UpdateBook(Book book)
    {
        _context.SaveChanges();
        return true;
    }

    public bool DeleteBook(int id)
    {
        Book? toDelete = _context.Books.FirstOrDefault(b => b.Id == id);
        if (toDelete != null)
        {
            _context.Books.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
