namespace LibraryManager;

using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;

    public LibraryDbContext(DbContextOptions<LibraryDbContext> Options) : base (Options)
    {
    }
}