using Project1.Dtos;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Services
{
    public class SongSerivce : IReadOnlySongService, IAddableSongSerivce, IDeleteableSongService
    {
        private readonly ISongRepository _repository;
        private readonly IReadOnlyRepositoryBase<SongModel> _readOnlySongRepository;
        private readonly IReadOnlyCategoryService _readOnlyCategoryService;
        private readonly IDateTimeService _dateTimeService;

        public IQueryable<SongModel> Songs { get; set; }


        public SongSerivce(
            ISongRepository repository,
            IReadOnlyRepositoryBase<SongModel> readOnlySongRepository,
            IReadOnlyCategoryService readOnlyCategoryService,
            IDateTimeService dateTimeService
            )
        {
            _repository = repository;
            _readOnlySongRepository = readOnlySongRepository;
            _readOnlyCategoryService = readOnlyCategoryService;
            _dateTimeService = dateTimeService;
        }

        // * Filtering
        // * Sorting
        // * Paging
        public IReadOnlySongService Load()
        {
            Songs = _readOnlySongRepository.GetAll();
            return this;
        }

        public IEnumerable<SongDto> GetData()
        {
            IEnumerable<SongDto> result = Songs.Select(p => new SongDto(
                p.Id,
                p.Title,
                p.ReleaseYear,
                p.Duration,
                p.Album,
                p.Artist,
                p.CategoryId,
                p.CategoryId != null ? _readOnlyCategoryService.GetById(p.CategoryId).Name : ""));

            return result;
        }

        public SongDto GetById(int id)
        {
            SongDto dto = Load()
                .GetData()
                .First(p => p.Id == id);

            return new SongDto(
                dto.Id,
                dto.Title,
                dto.ReleaseYear,
                dto.Duration,
                dto.Album,
                dto.Artist,
                dto.CategoryId,
                dto.CategoryName);
        }


        public void Create(NewSongDto newSongDto)
        {
            if (newSongDto == null)
            {
                throw new CreateSongServiceException("Create ist fehlgeschlagen: Dto ist leer!");
            }

            //title validation
            if (newSongDto.Title == null || newSongDto.Title == "" || newSongDto.Title.Trim() == "")
            {
                throw new CreateSongServiceException("Create ist fehlgeschlagen: Der Titel ist leer!");
            }

            if (newSongDto.Title.Length < 2)
            {
                throw new CreateSongServiceException("Create ist fehlgeschlagen: Der Titel ist zu kurz!");
            }

            //CategoryId validation
            if (newSongDto.CategoryId.Equals(0))
            {
                //instead of throwing an exception -> default 'other' is set
                newSongDto.CategoryId = CategoryModel.DEFAULT_CATEGORY_ID;
            }

            //artist validation
            if (newSongDto.Artist == null || newSongDto.Artist == "" || newSongDto.Artist.Trim() == "")
            {
                throw new CreateSongServiceException("Create ist fehlgeschlagen: Der Artist ist leer!");
            }


            SongModel newSongModel = new SongModel(
                newSongDto.Title,
                newSongDto.Duration,
                newSongDto.ReleaseYear,
                newSongDto.Album,
                newSongDto.Artist,
                newSongDto.CategoryId);


            try
            {
                _repository.Create(newSongModel);
            }
            catch (SongRepositoryCreateException ex)
            {
                throw new CreateSongServiceException("Create ist fehlgeschlagen!");
            }

        }

        public void Delete(int Id)
        {

            if (Id.Equals(0))
            {
                throw new DeleteSongServiceException("Delete ist fehlgeschlagen: Keine gültige Id wurde mitgeschickt!");
            }

            try
            {
                _repository.Delete(Id);
            }
            catch (SongRepositoryDeleteException ex)
            {
                throw new DeleteSongServiceException("Delete ist fehlgeschlagen!");
            }
        }

    }

}
