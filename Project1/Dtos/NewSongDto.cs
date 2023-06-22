using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Dtos
{

    public enum SongStateDto
    {

    }
    public class NewSongDto
    {

        public SongStateDto SongState { get; set; }
        [Required(ErrorMessage = "Pflichtfeld!")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Länge muss von 1 - 20 sein!")]
        public string Title { get; set; } = string.Empty;
        public String? Duration { get; set; }
        public String? ReleaseYear { get; set; }
        public String? Album { get; set; }
        [Required(ErrorMessage = "Pflichtfeld!")]
        public String? Artist { get; set;}
        [Required(ErrorMessage = "Pflichtfeld!")]
        public CategoryModel Category { get; set; }
        public int CategoryId { get; set; }

        [AllowNull]
        public IEnumerable<SelectListItem> PossibleCategories { get; set; }



}
}
