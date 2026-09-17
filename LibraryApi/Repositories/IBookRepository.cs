

using LibraryApi.Models;
namespace LibraryApi.Repositories;

public interface IBookRepository
{
    List <Book> GetAllBooks();
    Book? GetBookById(int id);
    void AddBook(Book book);
    int SaveChanges();
    bool DeleteBook(int id);
}