using System.ComponentModel.DataAnnotations;

namespace Project1.Dtos
{

    public enum PlaylistStateDto
    {

    }
    public class NewPlaylistDto
    {

        public PlaylistStateDto PlaylistState { get; set; }
        [Required(ErrorMessage = "Pflichtfeld!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Länge muss von 3 - 20 sein!")]
        [EmailAddress()]
        [RegularExpression("^[A-Z]")]
        public string Name { get; set; } = string.Empty;
        public String? CreationDate { get; set; }

}
}
