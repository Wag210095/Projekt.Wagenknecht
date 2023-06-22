namespace Project1.Dtos
{
    public class PlaylistListViewModel
    {

        public List<PlaylistDtoWithSongDto> Playlists { get; set; } = new List<PlaylistDtoWithSongDto>();
        public string SearchTerm { get; set; } = String.Empty;
    }
}
