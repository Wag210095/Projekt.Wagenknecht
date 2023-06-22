using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;
using System.Diagnostics;

namespace Project1.Controllers
{
    public class AddPlaylistController : Controller
    {


        private readonly IReadOnlyPlaylistService _readOnlyPlaylistService;
        private readonly IAddablePlaylistSerivce _addablePlaylistService;

        private readonly ProjectDbContext _db;

        private SongDto _songDto;

        public AddPlaylistController(
            IReadOnlyPlaylistService readOnlyPlaylistService,
            IAddablePlaylistSerivce addablePlaylistService,
            ProjectDbContext db)
        {
            _readOnlyPlaylistService = readOnlyPlaylistService;
            _addablePlaylistService = addablePlaylistService;
            _db = db;
        }


        public IActionResult Index()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        [HttpPost]
        public IActionResult AddPlaylist(NewPlaylistDto newPlaylistDto)
        {
            if (ModelState.IsValid)
            {

            }
            _addablePlaylistService.Create(newPlaylistDto);

            return View("SuccessfulSave");
        }


    }
}
