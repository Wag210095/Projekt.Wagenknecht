using Project1.Dtos;
using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlyPlaylistService
    {

        IQueryable<PlaylistModel> Playlists { get; set; }
        IReadOnlyPlaylistService Load();
        IEnumerable<PlaylistDto> GetData();

        PlaylistDto GetById(int Id);
    }
}
