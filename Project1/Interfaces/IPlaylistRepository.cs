using Project1.Models;

namespace Project1.Interfaces
{
    public interface IPlaylistRepository
    {
        void Create(PlaylistModel newEntity) {}

        void Delete(int Id) {}

    }
}
