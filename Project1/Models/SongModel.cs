using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Xml.Linq;

namespace Project1.Models
{

    public class SongModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowNull]
        public string? Duration { get; set; }
        [AllowNull]
        public string? ReleaseYear { get; set; }
        [AllowNull]
        public string? Album { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public int CategoryId { get; set; }

        protected SongModel() {}

        public CategoryModel _category = new();



        public SongModel(string title, string duration, string releaseYear, string album, string artist, int categoryId)
        {
            Title = title;
            Duration = duration;
            ReleaseYear = releaseYear;
            Album = album;
            Artist = artist;
            CategoryId = categoryId;
        }


    }

}
