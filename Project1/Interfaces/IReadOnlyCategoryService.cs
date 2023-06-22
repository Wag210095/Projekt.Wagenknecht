using Project1.Dtos;
using Project1.Models;

namespace Project1.Interfaces
{
    public interface IReadOnlyCategoryService
    {

        IQueryable<CategoryModel> Categories{ get; set; }
        IReadOnlyCategoryService Load();
        IEnumerable<CategoryDto> GetData();

        CategoryDto GetById(int Id);
    }
}
