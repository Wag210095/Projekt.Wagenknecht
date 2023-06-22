using Project1.Dtos;
using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlySongService
    {

        IQueryable<SongModel> Songs { get; set; }
        IReadOnlySongService Load();
        IEnumerable<SongDto> GetData();

        SongDto GetById(int Id);
    }
}
