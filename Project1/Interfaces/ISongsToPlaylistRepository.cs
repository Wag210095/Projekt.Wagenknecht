using Project1.Dtos;
using Project1.Models;

namespace Project1.Interfaces
{
    public interface ISongsToPlaylistRepository
    {

        void SaveAll(List<SongToPlaylistModel> models) { }
        void DeleteAll(List<SongToPlaylistModel> models) { }
    }
}
