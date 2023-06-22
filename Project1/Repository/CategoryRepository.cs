using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Repository
{
    public class CategoryRepository : IReadOnlyCategoryRepo
    {
       private readonly ProjectDbContext _db;

        public CategoryRepository(ProjectDbContext db)
        {
            _db = db;
        }


        public CategoryModel? GetByName(string name)
        {
            return _db.Categories.SingleOrDefault(e => e.Name == name);
        }

        public IQueryable<CategoryModel> GetAll()
            {
            return _db.Set<CategoryModel>();
        }

    }
}


