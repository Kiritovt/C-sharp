using LibraryApi.Repositories;
using LibraryApi.Services;
using LibraryApi.Models;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

string conn = builder.Configuration.GetConnectionString("LibraryConnection") ?? throw new InvalidOperationException("Connection string 'LibraryConnection' not found.");
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseNpgsql(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
