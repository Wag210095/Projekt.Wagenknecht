using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Context;
using Project1.Dtos;
using Project1.Interfaces;
using Project1.Models;
using System.Data;
using System.Diagnostics;

namespace Project1.Controllers
{
    public class AddSongController : Controller
    {


        private readonly IReadOnlySongService _readOnlySongService;
        private readonly IReadOnlyCategoryService _readOnlyCategoryService;
        private readonly IAddableSongSerivce _addableSongService;

        private readonly ProjectDbContext _db;

        private SongDto _song;

        public AddSongController(
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

        public IActionResult Index()
        {
            
            NewSongDto newSongDto = new NewSongDto();
            List<CategoryDto> categories = _readOnlyCategoryService
                            .Load()
                            .GetData()
                            .ToList();

            newSongDto.PossibleCategories = ToSelectList(categories);
            newSongDto.CategoryId = 8;

            return View(newSongDto);
        }

        [NonAction]
        public SelectList ToSelectList(List<CategoryDto> Dtos)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (CategoryDto dto in Dtos)
            {
                list.Add(new SelectListItem()
                {
                    Text = dto.Name,
                    Value = dto.Id.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult AddSong(NewSongDto newSongDto)
        {
            _addableSongService.Create(newSongDto);

            return View("SuccessfulSave");
        }
    }
}
