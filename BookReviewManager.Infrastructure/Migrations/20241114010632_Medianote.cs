using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReviewManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Medianote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MedianaNota",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedianaNota",
                table: "Books");
        }
    }
}
