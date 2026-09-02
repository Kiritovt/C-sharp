using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicationYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicationYear",
                table: "Books",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationYear",
                table: "Books");
        }
    }
}
