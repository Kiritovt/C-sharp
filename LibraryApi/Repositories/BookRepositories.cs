
using LibraryApi.Models;
namespace LibraryApi.Repositories;

public class BookRepository : IBookRepository
{
     private List<Book> _bookList = new List<Book>()
    {
        new Book {Id=1, Title= "How I Met Your Mother?", PublicationYear= 1998},
        new Book{Id= 2, Title="Is this the truth?", PublicationYear=2012 }
    };

    public List<Book> GetAllBooks()
    {
        return _bookList;
    }

    public Book? GetBookById(int id)
    {
        Book? bookFound = _bookList.FirstOrDefault(b=> b.Id == id);
        return bookFound;
    }

    public void AddBook(Book book)
    {
        if (_bookList.Any())
        {
            book.Id = _bookList.Max(b=>b.Id) + 1 ;
        }
        else
        {
            book.Id = 1;
        }
        _bookList.Add(book);
    }

    public bool UpdateBook(Book book)
    {
        Book? book1 = _bookList.FirstOrDefault(b => b.Id == book.Id);
        if (book1 != null)
        {
            book1.Title = book.Title;
            book1.PublicationYear = book.PublicationYear;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteBook(int id)
    {
        Book? toDelete = _bookList.FirstOrDefault(b => b.Id == id);
        if (toDelete != null)
        {
            _bookList.Remove(toDelete);
            return true;
        }
        else
        {
            return false;
        }
    }
}
