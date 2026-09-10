using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos;

public class CreateBookDto
{

    [Required]
    public string Title { set; get; } = null!;

    [Range(1000, 9999)]
    public int PublicationYear{ set; get; }
}