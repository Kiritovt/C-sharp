# LibraryManager

LibraryManager is a console application developed in C# as a learning project for Entity Framework Core and relational database management with PostgreSQL.

The project was created to practice the transition from manual database access with Npgsql to an ORM-based approach using Entity Framework Core.

## Technologies

- C#
- .NET 10
- Entity Framework Core
- Npgsql Entity Framework Core Provider
- PostgreSQL
- LINQ

## Project Structure

The application is based on two main entities:

### Author

An author contains:

- Id
- Name
- Surname
- Alias (optional)
- Collection of Books

### Book

A book contains:

- Id
- Title
- Genre
- PublicationYear (optional)
- AuthorId
- Author navigation property

The relationship between the entities is:

Author `1 : N` Books

An Author can have multiple Books, while each Book belongs to one Author.

## Features

The application currently supports:

- Insert a new author
- Show all authors
- Search authors by name
- Update an author's alias
- Delete an author
- Insert a new book
- Associate a book with an existing author
- Show all books with their authors
- Show an author with all related books
- Search books by author's surname
- Change the author associated with a book
- Search books by publication year

## Entity Framework Core Concepts Practiced

During the development of the project I practiced:

- `DbContext`
- `DbSet<T>`
- EF Core configuration with PostgreSQL
- Change Tracking
- `SaveChanges()`
- LINQ queries on `DbSet`
- `Where`
- `Any`
- `FirstOrDefault`
- `ToList`
- Navigation Properties
- Foreign Keys
- One-to-Many relationships
- `Include` and eager loading
- Cascade Delete
- Nullable properties
- EF Core Migrations
- Database schema updates

## Repository

Database operations are separated from the console interface through a `LibraryRepository`.

The console application is responsible for:

- User input
- Input validation
- Menu navigation
- Displaying results

The repository is responsible for interacting with Entity Framework Core and the database.

## Migrations

The database schema is managed through EF Core migrations.

The initial migration creates the `Authors` and `Books` tables and their relationship.

A subsequent migration adds the optional `PublicationYear` column to the `Books` table.

Example commands:

dotnet ef migrations add MigrationName

dotnet ef database update

## Database Configuration

The project uses PostgreSQL.

A valid PostgreSQL connection string must be configured locally before running the application.

Do not commit database passwords or other credentials to the repository.

Example:

Host=localhost;Port=5432;Database=library_manager;Username=postgres;Password=YOUR_PASSWORD

## Purpose

This project is part of my C#/.NET learning path.

Its main purpose is to understand how Entity Framework Core maps C# entities to a relational database and how CRUD operations, relationships, migrations and LINQ queries work without manually writing SQL commands.

The project is intentionally kept as a console application so the focus remains on Entity Framework Core and data access concepts.