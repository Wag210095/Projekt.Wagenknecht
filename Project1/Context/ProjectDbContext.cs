using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Context
{
    public class ProjectDbContext : DbContext
    {


        // Tables
        public DbSet<PlaylistModel> Playlists => Set<PlaylistModel>();
        public DbSet<CategoryModel> Categories => Set<CategoryModel>();
        public DbSet<SongModel> Songs => Set<SongModel>();
        public DbSet<SongToPlaylistModel> SongToPlaylist => Set<SongToPlaylistModel>();

        public ProjectDbContext()
        { }

        public ProjectDbContext(DbContextOptions options)
            : base(options)
        {
         
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MyConnection");
                optionsBuilder.UseSqlite(connectionString);
            }

        }

        public void Seed()
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>
            {
                new CategoryModel("Rock"),
                new CategoryModel("Pop"),
                new CategoryModel("Classic"),
                new CategoryModel("Disney"),
                new CategoryModel("Metal"),
                new CategoryModel("Dance"),
                new CategoryModel("Techno"),
                new CategoryModel("Other")
            };

            foreach (var category in categoryModels)
            {
                DbSet<CategoryModel> dbSet = this.Set<CategoryModel>();
                dbSet.Add(category);
                this.SaveChanges(); // => Insert
            }

        }
    }
}
