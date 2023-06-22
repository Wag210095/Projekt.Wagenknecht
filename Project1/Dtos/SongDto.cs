using System.Diagnostics.CodeAnalysis;

namespace Project1.Dtos
{
    public record SongDto
    (
        int Id,
        string Title,
        string ReleaseYear,
        string Duration,
        string Album,
        string Artist,
        int CategoryId,
        string? CategoryName
    )
    {
        public CategoryDto Category { get; set; }
    }
}
