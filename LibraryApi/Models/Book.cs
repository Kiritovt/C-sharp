using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; } = null!;
    [Range(1000, 9999)]
    public int PublicationYear { get; set; }
}