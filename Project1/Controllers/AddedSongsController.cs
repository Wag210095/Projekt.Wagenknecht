using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;

namespace Project1.Controllers
{
    public class AddedSongsController : Controller
    {
        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IReadOnlyCategoryService _readOnlyCategoryService;
        private readonly IAddableSongSerivce _addableSongService;

        private readonly ProjectDbContext _db;

        private SongDto _song;

        public AddedSongsController(
            IReadOnlySongService readOnlySongService,
            IReadOnlyCategoryService readOnlyCategoryService,
            IAddableSongSerivce addableSongService,
            ProjectDbContext db)
        {
            _readOnlySongService = readOnlySongService;
            _readOnlyCategoryService = readOnlyCategoryService;
            _addableSongService = addableSongService;
            _db = new ProjectDbContext();
        }

        public IActionResult Index(SongsToPlaylistDto addSongsToPlaylistDto)
        {
            return View();
        }
    }
}
