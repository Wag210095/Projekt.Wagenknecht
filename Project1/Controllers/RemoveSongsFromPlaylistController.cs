using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Controllers
{
    public class RemoveSongsFromPlaylistController : Controller
    {

        private readonly IReadOnlyPlaylistService _readOnlyPlaylistService;
        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IRemoveSongsFromPlaylistService _removeSongsFromPlaylistService;

        private readonly ProjectDbContext _db;


        public RemoveSongsFromPlaylistController(
            IReadOnlyPlaylistService readOnlyPlaylistService,
            IReadOnlySongService readOnlySongService,
            IAddablePlaylistSerivce addablePlaylistService,
            IRemoveSongsFromPlaylistService removeSongsFromPlaylistService,
            ProjectDbContext db)
        {
            _readOnlyPlaylistService = readOnlyPlaylistService;
            _readOnlySongService = readOnlySongService;
            _removeSongsFromPlaylistService = removeSongsFromPlaylistService;
            _db = db;
        }



        public IActionResult Index(int Id)
        {
            SongsToPlaylistDto dto = new SongsToPlaylistDto();
            dto.PlaylistId = Id;

            //only models that are not part of the playlist
            List<int> alreadyAssignedSongIds = _db
                .SongToPlaylist
                .Where(StP => StP.PlaylistId == Id)
                .Select(StP => StP.SongId)
                .ToList();

            //all songs - nur die bereits vergebene
            List<SongDto> songs = _readOnlySongService
                .Load()
                .GetData()
                .Where(s => alreadyAssignedSongIds.Contains(s.Id))
                .ToList();


            dto.PossibleSongs = ToSelectList(songs);

            return View("Index", dto);
        }

        [NonAction]
        public SelectList ToSelectList(List<SongDto> Dtos)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (SongDto dto in Dtos)
            {
                list.Add(new SelectListItem()
                {
                    Text = dto.Artist + " - " + dto.Title,
                    Value = dto.Id.ToString()
                }); ;
            }

            return new SelectList(list, "Value", "Text");
        }


        [HttpPost]
        public IActionResult Remove(SongsToPlaylistDto dto)
        {
            _removeSongsFromPlaylistService.Remove(dto);
            return View("SuccessfulSave");

        }
    }
}
