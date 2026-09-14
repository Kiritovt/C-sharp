

using LibraryApi.Models;
namespace LibraryApi.Repositories;

public interface IBookRepository
{
    List <Book> GetAllBooks();
    Book? GetBookById(int id);
    void AddBook(Book book);
    bool UpdateBook(Book book);
    bool DeleteBook(int id);
}