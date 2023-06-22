using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Repository
{
    public class PlaylistRepository : IPlaylistRepository, IReadOnlyPlaylistRepo
    {
       private readonly ProjectDbContext _db;

            public PlaylistRepository(ProjectDbContext db)
            {
                _db = db;
            }

            public void Create(PlaylistModel newEntity)
            {
                try
                {
                    DbSet<PlaylistModel> dbSet = _db.Set<PlaylistModel>();
                    dbSet.Add(newEntity);
                    _db.SaveChanges(); // => Insert
                }
                catch (DbUpdateException ex)
                {
                    throw new PlaylistRepositoryCreateException("Create nicht möglich!", ex);
                }
            }

            public void Delete(int Id)
            {
                try
                {
                    _db.Remove(_db.Playlists.Single(a => a.Id == Id));
                    _db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw new PlaylistRepositoryDeleteException("Delete nicht möglich!", ex);
                }
            }

            public PlaylistModel? GetByName(string name)
            {
                return _db.Playlists.SingleOrDefault(e => e.Name == name);
            }

            public IQueryable<PlaylistModel> GetAll()
            {
                return _db.Set<PlaylistModel>();
            }
        
    }
}


