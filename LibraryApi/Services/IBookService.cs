using LibraryApi.Dtos;
using LibraryApi.Models;
namespace LibraryApi.Services;

public interface IBookService{
    List<Book> GetBooks(int? year);

    Book? GetBookById(int id);

    Book CreateBook(CreateBookDto bookDto);

    bool UpdateBook(int id, UpdateBookDto bookDto);

    bool DeleteBook(int id);
}
