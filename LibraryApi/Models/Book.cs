namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int PublicationYear { get; set; }

}