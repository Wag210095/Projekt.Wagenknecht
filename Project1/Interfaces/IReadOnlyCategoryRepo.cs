using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlyCategoryRepo
    {

        CategoryModel? GetByName(string name);

        IQueryable<CategoryModel> GetAll();
    }
}
