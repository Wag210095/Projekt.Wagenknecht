using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Dtos
{
    public class SongsToPlaylistDto
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public List<int> SongIds { get; set; }
        public IEnumerable<SelectableSongDto> Songs { get; set; } = Enumerable.Empty<SelectableSongDto>();

        [AllowNull]
        public IEnumerable<SelectListItem> PossibleSongs { get; set; }


        public int SongsCount => PossibleSongs != null ? PossibleSongs.Count() : 0;
    }
}
