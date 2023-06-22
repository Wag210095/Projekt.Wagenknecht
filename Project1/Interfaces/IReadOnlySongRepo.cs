using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlySongRepo
    {

        SongModel? GetByName(string name);

        IQueryable<SongModel> GetAll();
    }
}
