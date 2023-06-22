using Project1.Dtos;
using Project1.Exceptions;
using Project1.Helpers;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Services

{
    public class SongsToPlaylistService : IAddSongsToPlaylistService, IRemoveSongsFromPlaylistService
    {

        private readonly ISongsToPlaylistRepository _repository;
        private readonly IReadOnlyRepositoryBase<SongToPlaylistModel> _readOnlySongsToPlaylistRepository;

        public IQueryable<SongModel> Songs { get; set; }


        public SongsToPlaylistService(
            ISongsToPlaylistRepository repository,
            IReadOnlyRepositoryBase<SongToPlaylistModel> readOnlySongToPlaylistRepository
        )
        {
            _repository = repository;
            _readOnlySongsToPlaylistRepository = readOnlySongToPlaylistRepository;
        }

        public void Save(SongsToPlaylistDto addSongsToPlaylistDto)
        {
          
            List<SongToPlaylistModel> models = new List<SongToPlaylistModel>();
          
            foreach(var id in addSongsToPlaylistDto.SongIds)
            {
                models.Add(new SongToPlaylistModel(addSongsToPlaylistDto.PlaylistId, id));
            }

            try
            {
                _repository.SaveAll(models);
            }
            catch (AddSongsToPlaylistServiceException ex)
            {
                throw new AddSongsToPlaylistServiceException("Hinzufügen/Entfernen ist fehlgeschlagen!");
            }
        }

        public void Remove(SongsToPlaylistDto songsToPlaylistDto)
        {

            List<SongToPlaylistModel> models = new List<SongToPlaylistModel>();

            foreach (var id in songsToPlaylistDto.SongIds)
            {
                models.Add(new SongToPlaylistModel(songsToPlaylistDto.PlaylistId, id));
            }

            try
            {
                _repository.DeleteAll(models);
            }
            catch (AddSongsToPlaylistServiceException ex)
            {
                throw new AddSongsToPlaylistServiceException("Hinzufügen/Entfernen ist fehlgeschlagen!");
            }
        }
    }
}
