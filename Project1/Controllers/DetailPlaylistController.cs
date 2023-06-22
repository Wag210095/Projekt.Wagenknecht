using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Controllers
{

    public class DetailPlaylistController : Controller
    {

        private readonly IReadOnlyPlaylistService _readOnlyPlaylistService;
        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IAddablePlaylistSerivce _addablePlaylistService;

        private readonly ProjectDbContext _db;

        public DetailPlaylistController(
            IReadOnlyPlaylistService readOnlyPlaylistService,
            IReadOnlySongService readOnlySongService,
            IAddablePlaylistSerivce addablePlaylistService,
            ProjectDbContext db)
        {
            _readOnlyPlaylistService = readOnlyPlaylistService;
            _addablePlaylistService = addablePlaylistService;
            _readOnlySongService = readOnlySongService;
            _db = db;
        }


        [HttpGet()]
        public IActionResult Details(int Id)
        {
            PlaylistDto playlistDto = _readOnlyPlaylistService
                .GetById(Id);

            List<SongToPlaylistModel> mappings = _db
                .SongToPlaylist
                .Where(StP => StP.PlaylistId == playlistDto.Id)
                .ToList();

            List<SongModel> songEntries = new List<SongModel>();

            PlaylistDtoWithSongDto playlistDtoWithSongDto = new PlaylistDtoWithSongDto();
            playlistDtoWithSongDto.Id = playlistDto.Id;
            playlistDtoWithSongDto.Name = playlistDto.Name;
            playlistDtoWithSongDto.CreationDate = playlistDto.CreationDate;
            playlistDtoWithSongDto.UpdateDate = playlistDto.UpdateDate;
            playlistDtoWithSongDto.SongCount = mappings.Count();

            foreach (SongToPlaylistModel song in mappings)
            {
                playlistDtoWithSongDto.Songs.Add(_readOnlySongService.GetById(song.SongId));

            }

            return View("Index", playlistDtoWithSongDto);
        }




    }
}
