using System.Security.Cryptography.X509Certificates;
using LibraryManager;
using Microsoft.EntityFrameworkCore;
using static System.Console;

class Program
{
    public static void Main(string[] args) {

        bool turnOff = false;
        string connectionString = "Host=localhost;Port=5432;Database=library_manager;Username=postgres;Password=";
        var optionBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionBuilder.UseNpgsql(connectionString);
        var options = optionBuilder.Options;
        LibraryDbContext library = new LibraryDbContext(options);
        LibraryRepository libraryRepository = new LibraryRepository(library);

        while(!turnOff){
            Console.WriteLine("Welcome to the Library Manager.\nChoose the function that you want to use:\n1. Insert a New Author\n2. Show Authors List\n3. Search Author by Name\n4. Update Author Alias\n5. Delete Author By Id\n6. Insert a New Book\n7. Show Books List with Authors\n8. Get Author info\n9. Search Author's Books by surname\n10. Change Book's Author\n11. Search Books for Publication Year\n0. Turn Off the application ");
            int choice = ReadNumber("Enter the choice:");
            switch (choice)
            {
                case 1:
                    Author a = new Author();
                    while (true)
                    {
                        Console.WriteLine("Insert the Name:");
                        a.Name = Console.ReadLine()?? "";
                        Console.WriteLine("Insert the Surname:");
                        a.Surname = Console.ReadLine() ?? "";
                        Console.WriteLine("Insert the alias");
                        a.Alias = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(a.Name) || string.IsNullOrWhiteSpace(a.Surname))
                        {
                            Console.WriteLine("Invalid Author please enter a valid Name and Surname!");
                        }
                        else
                        {
                            break;
                        }
                    }
                    libraryRepository.InsertAuthor(a);
                    break;

                case 2:
                    List<Author> getAll = libraryRepository.GetAllAuthors();
                    if (getAll.Any())
                    {
                        foreach (Author at in getAll)
                        {
                            Console.WriteLine($"{at.Id}. {at.Name} {at.Surname} {at.Alias}");

                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no Authors in the database.");
                    }
                    break;

                case 3:
                    string name;
                    while (true){
                        Console.WriteLine("Enter the Author's Name:");
                        name= Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid Name, please retry.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    List<Author> filtered = libraryRepository.SearchByNameAuthor(name);
                    if (filtered.Any())
                    {
                        foreach(Author at in filtered)
                        {
                            Console.WriteLine($"{at.Id}. {at.Name} {at.Surname} {at.Alias}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no Author with the Name: {name}");
                    }
                    break;

                case 4:
                    int id = ReadNumber("Enter the author Id:");
                    Console.WriteLine("Enter the new Author Alias");
                    string alias = Console.ReadLine() ?? "";
                    bool check = libraryRepository.UpdateAuthor(id, alias);
                    if (check)
                    {
                        Console.WriteLine("Author's Alias changed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Author not found.");
                    }
                    break;

                case 5:
                    id = ReadNumber("Enter the Author's id:");
                    check = libraryRepository.DeleteAuthor(id);
                    if (check)
                    {
                        Console.WriteLine("Author successfully deleted!");
                    }
                    else
                    {
                        Console.WriteLine("No Author Found");
                    }
                    break;

                case 6:
                    Book b = new Book();
                    string? publicationYear;
                    while (true)
                    {
                        id = ReadNumber("Enter the Author's Id:");
                        if (libraryRepository.AuthorExist(id))
                        {
                            b.AuthorId = id;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please retry.");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter the Book's title:");
                        b.Title = Console.ReadLine()?? "";
                        Console.WriteLine("Enter the Genre:");
                        b.Genre = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(b.Title) || string.IsNullOrWhiteSpace(b.Genre))
                        {
                            Console.WriteLine("Invalid Book, please retry entering the title and the genre.");
                        }
                        else
                        {
                            break;
                        }

                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the PublicationYear:");
                        publicationYear = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(publicationYear))
                            {

                                b.PublicationYear = null;
                                break;
                            }
                        else if (int.TryParse(publicationYear, out int number))
                        {
                                b.PublicationYear = number;
                                break;
                            }
                        else
                        {
                            Console.WriteLine("Invalid PublicationYear");
                        }
                    }
                    libraryRepository.InsertBook(b);
                    break;

                case 7:
                    List<Book> getAllBooks = libraryRepository.GetAllBooks();
                    if (getAllBooks.Any())
                    {
                         foreach (Book book in getAllBooks)
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} {book.Genre} - {book.Author.Name} {book.Author.Surname} {book.Author.Alias}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no books in the database.");
                    }
                    break;

                case 8:
                    id = ReadNumber("Enter the Author Id:");
                    var authorInfo = libraryRepository.GetAuthor(id);
                    if (authorInfo != null)
                    {
                        Console.WriteLine($"{authorInfo.Name} {authorInfo.Surname} {authorInfo.Alias}");
                        if (authorInfo.Books.Any())
                        {
                            foreach (Book book in authorInfo.Books)
                            {
                                Console.WriteLine($"{book.Id}. {book.Title} {book.Genre}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This Author has no books at the moment.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"There is no Author with the id:{id}");
                    }
                    break;

                case 9:
                    string surname;
                    while (true)
                    {
                        Console.WriteLine("Enter the Author's surname");
                        surname = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(surname) || !libraryRepository.AuthorExistBySurname(surname))
                        {
                            Console.WriteLine("Invalid Surname, please retry");
                        }
                        else
                        {
                            break;
                        }
                    }
                    List<Book> authorBooks = libraryRepository.GetAuthorBooksBySurname(surname);
                    if (authorBooks.Any())
                    {
                        foreach (Book book in authorBooks)
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} - {book.Genre}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The Author has no books at the moment.");
                    }
                    break;

                case 10:
                    int authorId;
                    while (true)
                    {
                         authorId= ReadNumber("Enter the Author's Id:");
                        if (libraryRepository.AuthorExist(authorId))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There is no Author with the Id:");
                        }
                    }

                    int bookId = ReadNumber("Enter the Book's Id:");
                    if (libraryRepository.UpdateBookAuthorId(bookId, authorId))
                    {
                        Console.WriteLine("Book's Author Updated.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                    break;

                case 11:
                    Console.WriteLine("Enter the PublicationYear:");
                    publicationYear = Console.ReadLine();
                    if (int.TryParse(publicationYear, out int num))
                    {
                        List<Book> bookFiltered = libraryRepository.GetBooksByPublicationYear(num);
                        if (bookFiltered.Any())
                        {
                            foreach (Book filter in bookFiltered)
                            {
                                Console.WriteLine($"{filter.Id}. {filter.Title} {filter.Genre} {filter.PublicationYear}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no books for the current Publication Year.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                        break;



                case 0:
                    turnOff = true;
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        } }

    public static int ReadNumber(string message)
    {

        while (true)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}












































