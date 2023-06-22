using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;

namespace Project1.Controllers
{

    public class DetailSongController : Controller
    {

        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IReadOnlyCategoryService _readOnlyCategoryService;
        private readonly IAddableSongSerivce _addableSongService;

        private readonly ProjectDbContext _db;

        public DetailSongController(
            IReadOnlySongService readOnlySongService,
            IReadOnlyCategoryService readOnlyCategoryService,
            IAddableSongSerivce addableSongSerivce,
            ProjectDbContext db)
        {
            _readOnlySongService = readOnlySongService;
            _readOnlyCategoryService = readOnlyCategoryService; 
            _addableSongService = addableSongSerivce;
            _db = db;
        }

        [HttpGet()]
        public IActionResult Details(int Id)
        {
            SongDto songDto = _readOnlySongService
                .GetById(Id);

            return View("Index", songDto);
        }




    }
}
