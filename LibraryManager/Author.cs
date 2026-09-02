namespace LibraryManager;

public class Author
{
    public int Id{get; set;}
    public string Name {get; set;} = "";
    public string Surname {get; set;} ="";
    public string? Alias {get; set;}
    public List<Book> Books {get; set;} =[];
}