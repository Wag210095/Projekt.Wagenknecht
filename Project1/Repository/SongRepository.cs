using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Repository
{
    public class SongRepository : ISongRepository, IReadOnlySongRepo
    {
       private readonly ProjectDbContext _db;

        public SongRepository(ProjectDbContext db)
        {
            _db = db;
        }

        public void Create(SongModel newEntity)
        {
            try
            {
                DbSet<SongModel> dbSet = _db.Set<SongModel>();
                dbSet.Add(newEntity);
                _db.SaveChanges(); // => Insert
            }
            catch (DbUpdateException ex)
            {
                throw new SongRepositoryCreateException("Create nicht möglich!", ex);
            }
        }

        public void Delete(int Id)
        {
            try
            {
                _db.Remove(_db.Songs.Single(a => a.Id == Id));
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new SongRepositoryDeleteException("Delete nicht möglich!", ex);
            }
        }

        public SongModel? GetByName(string name)
            {
                return _db.Songs.SingleOrDefault(e => e.Title == name);
            }

            public IQueryable<SongModel> GetAll()
            {
                return _db.Set<SongModel>();
            }
        
    }
}


