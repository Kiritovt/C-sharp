namespace LibraryManager;

using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
public class LibraryRepository
{
    private readonly LibraryDbContext _library;

    public LibraryRepository(LibraryDbContext library)
    {
        _library = library;
    }

    public void InsertAuthor(Author author)
    {
        _library.Authors.Add(author);
        _library.SaveChanges();
    }

    public List<Author> GetAllAuthors()
    {
        return _library.Authors.ToList();
    }

    public List<Author> SearchByNameAuthor(string filter)
    {
       return _library.Authors.Where(a => a.Name == filter).ToList();
    }

    public bool UpdateAuthor(int id, string alias)
    {
        var filter = _library.Authors.FirstOrDefault(a => a.Id == id);
        if (filter != null)
        {
            filter.Alias = alias;
            _library.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteAuthor(int id)
    {
        var filtered = _library.Authors.FirstOrDefault(a => a.Id == id);
        if (filtered != null)
        {
            _library.Authors.Remove(filtered);
            _library.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AuthorExist(int id)
    {
        return _library.Authors.Any(a => a.Id == id);
        // You could use the extended version like: 
        // if (_library.Authors.Any(a => a.Id == id))
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
        // Any already returns a bool, so no if/else is needed.    
    }



    public bool AuthorExistBySurname(string surname)
    {
       return _library.Authors.Any(a=> a.Surname == surname);
    }


    public void InsertBook(Book book)
    {
        _library.Books.Add(book);
        _library.SaveChanges();
    }

    public List<Book> GetAllBooks()
    {
        return _library.Books.Include(b=> b.Author).ToList();
    }

    public Author? GetAuthor(int id)
    {
        return _library.Authors.Include(a=> a.Books).FirstOrDefault(a=> a.Id == id);
    }

    public List<Book> GetAuthorBooksBySurname(string surname)
    {
        return _library.Books.Where(b=> b.Author.Surname== surname).ToList();
    }

    public bool UpdateBookAuthorId(int bookId, int authorId)
    {
        var filtered = _library.Books.FirstOrDefault(b=>b.Id == bookId);
        if (filtered != null)
        {
            filtered.AuthorId = authorId;
            _library.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Book> GetBooksByPublicationYear(int year)
    {
        return _library.Books.Where(b=> b.PublicationYear == year).ToList();
    }
}

























