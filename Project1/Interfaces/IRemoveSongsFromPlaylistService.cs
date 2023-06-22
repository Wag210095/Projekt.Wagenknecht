using Project1.Dtos;

namespace Project1.Interfaces
{
    public interface IRemoveSongsFromPlaylistService
    {

        void Remove(SongsToPlaylistDto songsToPlaylistDto);
    }
}
