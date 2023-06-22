using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlyPlaylistRepo
    {

        PlaylistModel? GetByName(string name);

        IQueryable<PlaylistModel> GetAll();
    }
}
