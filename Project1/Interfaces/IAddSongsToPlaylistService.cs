using Project1.Dtos;

namespace Project1.Interfaces
{
    public interface IAddSongsToPlaylistService
    {

        void Save(SongsToPlaylistDto songsToPlaylistDto);
    }
}
