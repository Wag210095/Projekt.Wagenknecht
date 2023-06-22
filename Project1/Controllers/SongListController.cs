using Microsoft.AspNetCore.Mvc;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;
using System.Diagnostics;

namespace Project1.Controllers
{
    public class SongListController : Controller
    {

        private readonly IReadOnlySongService _readOnlySongService;
        private readonly ProjectDbContext _db;

        public SongListController(
            IReadOnlySongService readOnlySongService,
            IReadOnlyCategoryService readOnlyCategoryService,
            ProjectDbContext db)
        {
            _readOnlySongService = readOnlySongService;
            _db = db;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            IEnumerable<SongDto> model = _readOnlySongService
                .Load()
                .GetData();


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
