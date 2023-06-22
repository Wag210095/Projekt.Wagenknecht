using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Exceptions;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.Repository
{
    public class SongsToPlaylistRepository : ISongsToPlaylistRepository
    {

        private readonly ProjectDbContext _db;

        public SongsToPlaylistRepository(ProjectDbContext db)
        {
            _db = db;
        }

        public void SaveAll(List<SongToPlaylistModel> Models)
        {
            try
            {
                DbSet<SongToPlaylistModel> dbSet = _db.Set<SongToPlaylistModel>();

                foreach (SongToPlaylistModel model in Models)
                {
                    dbSet.Add(model);
                }
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new SongToPlaylistRepositoryAddException("Hinzufügen/ Entfernen nicht möglich!", ex);
            }
        }
        public void DeleteAll(List<SongToPlaylistModel> Models)
        {
            try
            {
                DbSet<SongToPlaylistModel> dbSet = _db.Set<SongToPlaylistModel>();

                foreach (SongToPlaylistModel model in Models)
                {
                    List<SongToPlaylistModel> songToPlaylistModels = _db.Set<SongToPlaylistModel>()
                        .Where(x => x.PlaylistId == model.PlaylistId && x.SongId == model.SongId)
                        .ToList();

                    foreach(SongToPlaylistModel songToPlaylistModel in songToPlaylistModels)
                    {
                        dbSet.Remove(songToPlaylistModel);
                    }

                }
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new SongToPlaylistRepositoryAddException("Hinzufügen/ Entfernen nicht möglich!", ex);
            }
        }

    }
}
