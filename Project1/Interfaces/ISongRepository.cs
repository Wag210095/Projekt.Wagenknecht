using Project1.Models;

namespace Project1.Interfaces
{
    public interface ISongRepository
    {
        void Create(SongModel newEntity) {}

        void Delete(int Id) { }
    }
}
