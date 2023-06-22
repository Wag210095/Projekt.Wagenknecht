using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Controllers
{
    public class DeleteSongController : Controller
    {


        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IDeleteableSongService _deleteableSongService;

        private readonly ProjectDbContext _db;

        [AllowNull]
        private SongDto _songDto;

        public DeleteSongController(
            IReadOnlySongService readOnlySongService,
            IDeleteableSongService deleteableSongService,
            ProjectDbContext db)
        {
            _readOnlySongService = readOnlySongService;
            _deleteableSongService = deleteableSongService;
            _db = db;
        }

        [HttpGet()]
        public IActionResult ConfirmDelete(int Id)
        {
            _songDto = _readOnlySongService.GetById(Id);

            return View("ConfirmDelete", _songDto);
        }


        [HttpGet()]
        public IActionResult DeleteSong(int Id)
        {
            _songDto = _readOnlySongService.GetById(Id);


            if (_songDto == null)
            {
                //todo throw error
                return View("Error");
            }
            else
            {
                _deleteableSongService.Delete(_songDto.Id);
                return View("DeleteDone");
            }

        }
    }
}
