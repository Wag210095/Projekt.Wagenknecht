using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Controllers
{
    public class DeletePlaylistController : Controller
    {

        private readonly IReadOnlyPlaylistService _readOnlyPlaylistService;
        private readonly IDeleteablePlaylistService _deleteablePlayService;

        private readonly ProjectDbContext _db;

        [AllowNull]
        private PlaylistDto _playlistDto;

        public DeletePlaylistController(
            IReadOnlyPlaylistService readOnlyPlaylistService,
            IDeleteablePlaylistService deleteablePlaylistService,
            ProjectDbContext db)
        {
            _readOnlyPlaylistService = readOnlyPlaylistService;
            _deleteablePlayService = deleteablePlaylistService;
            _db = db;
        }

        [HttpGet()]
        public IActionResult ConfirmDelete(int Id)
        {
            _playlistDto = _readOnlyPlaylistService.GetById(Id);

            return View("ConfirmDelete", _playlistDto);
        }


        [HttpGet()]
        public IActionResult DeletePlaylist(int Id)
        {
            _playlistDto = _readOnlyPlaylistService.GetById(Id);


            if (_playlistDto == null)
            {
                //todo throw error
                return View("Error");
            } else
            {
                _deleteablePlayService.Delete(_playlistDto.Id);
                return View("DeleteDone");
            }

        }
    }
}
