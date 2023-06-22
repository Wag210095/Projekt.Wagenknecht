using Project1.Context;
using Project1.Dtos;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;
using System.Collections.Generic;

namespace Project1.Services
{
    public class PlaylistSerivce : IReadOnlyPlaylistService, IAddablePlaylistSerivce, IDeleteablePlaylistService
    {
        private readonly IPlaylistRepository _repository;
        private readonly IReadOnlyRepositoryBase<PlaylistModel> _readOnlyPlaylistRepository;
        private readonly IDateTimeService _dateTimeService;

        private readonly ProjectDbContext _db;

        public IQueryable<PlaylistModel> Playlists { get; set; }


        public PlaylistSerivce(
            IPlaylistRepository repository,
            IReadOnlyRepositoryBase<PlaylistModel> readOnlyPlaylistRepository,
            IDateTimeService dateTimeService,
            ProjectDbContext db
            )
        {
            _repository = repository;
            _readOnlyPlaylistRepository = readOnlyPlaylistRepository;
            _dateTimeService = dateTimeService;
            _db = db;

        }

        // * Filtering
        // * Sorting
        // * Paging
        public IReadOnlyPlaylistService Load()
        {
            Playlists = _readOnlyPlaylistRepository.GetAll();
            return this;
        }

        public IEnumerable<PlaylistDto> GetData()
        {
            IEnumerable<PlaylistDto> result = Playlists
                .Select(p => new PlaylistDto(
                        p.Id,
                        p.Name,
                        p.CreationDate,
                        p.UpdateDate));


            return result;
        }

        public IEnumerable<PlaylistDto> UseFilterContainsName(string searchTerm)
        {
            IEnumerable<PlaylistDto> result = Playlists
                .Select(p => new PlaylistDto(
                        p.Id,
                        p.Name,
                        p.CreationDate,
                        p.UpdateDate));


            return result;
        }


        public PlaylistDto GetById(int id)
        {
            PlaylistDto model = Load()
                .GetData()
                .First(p => p.Id == id);

            return new PlaylistDto(model.Id, model.Name, model.CreationDate, model.UpdateDate);
        }


        public void Create(NewPlaylistDto newPlaylistDto)
        {

            if (newPlaylistDto == null)
            {
                throw new CreatePlaylistServiceException("Create ist fehlgeschlagen: Dto ist leer!");
            }

            //name validation
            if (newPlaylistDto.Name == null || newPlaylistDto.Name == "" || newPlaylistDto.Name.Trim() == "")
            {
                throw new CreatePlaylistServiceException("Create ist fehlgeschlagen: Der Name ist leer!");
            }

            if (newPlaylistDto.Name.Length < 2)
            {
                throw new CreatePlaylistServiceException("Create ist fehlgeschlagen: Der Name ist zu kurz!");
            }

            PlaylistModel newPlaylist = new PlaylistModel(
                newPlaylistDto.Name,
                _dateTimeService.Now.ToShortDateString());


            try
            {
                _repository.Create(newPlaylist);
            }
            catch (PlaylistRepositoryCreateException ex)
            {
                throw new CreatePlaylistServiceException("Create ist fehlgeschlagen!");
            }
        }

        public void Delete(int Id)
        {

            if (Id.Equals(0))
            {
                throw new PlaylistRepositoryDeleteException("Delete ist fehlgeschlagen: Keine gültige Id wurde mitgeschickt!");
            }

            try
            {
                _repository.Delete(Id);
            }
            catch (PlaylistRepositoryDeleteException ex)
            {
                throw new PlaylistRepositoryDeleteException("Delete ist fehlgeschlagen!");
            }
        }

    }

}
