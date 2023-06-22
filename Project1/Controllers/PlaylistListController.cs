using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;
using Project1.ServiceExtension;
using System.Diagnostics;

namespace Project1.Controllers
{
    public class PlaylistListController : Controller
    {
        private readonly IReadOnlyPlaylistService _readOnlyPlaylistService;
        private readonly IReadOnlySongService _readOnlySongService;
        private readonly ProjectDbContext _db;


        public PlaylistListController(
            IReadOnlyPlaylistService readOnlyPlaylistService,
            IReadOnlySongService readOnlySongService,
            ProjectDbContext db)
        {
            _readOnlyPlaylistService = readOnlyPlaylistService;
            _readOnlySongService = readOnlySongService;
            _db = db;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return SearchWithOutSearchTerm();
        }


        [HttpPost()]
        public IActionResult Reset(PlaylistListViewModel model)
        {
            return SearchWithOutSearchTerm();

        }

        private IActionResult SearchWithOutSearchTerm()
        {
            PlaylistListViewModel result = new PlaylistListViewModel();
            List<PlaylistDtoWithSongDto> model = new List<PlaylistDtoWithSongDto>();

            List<PlaylistDto> dtos = _readOnlyPlaylistService
                .Load()
                .GetData()
                .ToList();

            foreach (PlaylistDto dto in dtos)
            {
                List<SongToPlaylistModel> mappings = _db
                    .SongToPlaylist
                    .Where(StP => StP.PlaylistId == dto.Id)
                    .ToList();

                List<SongModel> songEntries = new List<SongModel>();

                PlaylistDtoWithSongDto playlistDtoWithSongDto = new PlaylistDtoWithSongDto();
                playlistDtoWithSongDto.Id = dto.Id;
                playlistDtoWithSongDto.Name = dto.Name;
                playlistDtoWithSongDto.CreationDate = dto.CreationDate;
                playlistDtoWithSongDto.UpdateDate = dto.UpdateDate;
                playlistDtoWithSongDto.SongCount = mappings.Count();

                foreach (SongToPlaylistModel song in mappings)
                {
                    playlistDtoWithSongDto.Songs.Add(_readOnlySongService.GetById(song.SongId));

                }


                model.Add(playlistDtoWithSongDto);
            }

            result.Playlists = model;

            return View("Index", result);
        }

        [HttpPost]
        public IActionResult Search(PlaylistListViewModel param)
        {
            PlaylistListViewModel result = new PlaylistListViewModel();
            List<PlaylistDtoWithSongDto> model = new List<PlaylistDtoWithSongDto>();

            List<PlaylistDto> dtos = _readOnlyPlaylistService
                .Load()
                .UseFilterContainsName(param.SearchTerm)
                .GetData()
                .ToList();

            foreach (PlaylistDto dto in dtos)
            {
                List<SongToPlaylistModel> mappings = _db
                    .SongToPlaylist
                    .Where(StP => StP.PlaylistId == dto.Id)
                    .ToList();

                List<SongModel> songEntries = new List<SongModel>();

                PlaylistDtoWithSongDto playlistDtoWithSongDto = new PlaylistDtoWithSongDto();
                playlistDtoWithSongDto.Id = dto.Id;
                playlistDtoWithSongDto.Name = dto.Name;
                playlistDtoWithSongDto.CreationDate = dto.CreationDate;
                playlistDtoWithSongDto.UpdateDate = dto.UpdateDate;
                playlistDtoWithSongDto.SongCount = mappings.Count();

                foreach (SongToPlaylistModel song in mappings)
                {
                    playlistDtoWithSongDto.Songs.Add(_readOnlySongService.GetById(song.SongId));

                }

                model.Add(playlistDtoWithSongDto);
            }

            result.Playlists = model;

            return View("Index", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
