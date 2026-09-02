using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace LibraryManager;

public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
{
    public LibraryDbContext CreateDbContext(string[] args)
    {
        string _conn = "Host=localhost;Port=5432;Database=library_manager;Username=postgres;Password=DemetraFormazione_18";

        var optionBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionBuilder.UseNpgsql(_conn);
        var option = optionBuilder.Options;
        LibraryDbContext Library = new LibraryDbContext(option);
        return Library;
    }

}