using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Dtos;
using Project1.Models;
using Project1.Repository;
using Project1.Services;
using Project1.Test.Helpers;
using Project1.Test.Mock;
using Xunit;




namespace Project1.Test
{
    public class PlaylistServiceTest
    {

        private PlaylistSerivce InitUnitToTest(ProjectDbContext db)
        {
            return new PlaylistSerivce(
                new PlaylistRepository(db),
                new RepositoryBase<PlaylistModel>(db),
                new DateTimeServiceMock(),
                db);
        }

        private DbContextOptions GenerateDbOptions()
        {
            SqliteConnection connection = new SqliteConnection("Data Source = :memory:");
            connection.Open();

            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite(connection);
            return options.Options;
        }

        [Fact]
        public void CreatePlaylist_Success_Test()
        {
            // Arrange
            using (ProjectDbContext db = new ProjectDbContext(GenerateDbOptions()))
            {
                PlaylistSerivce unitToTest = InitUnitToTest(db);

                DatabaseUtilities.InitializeDatabase(db);

                NewPlaylistDto entity = new NewPlaylistDto()
                {
                    Name = "Test Playlist 1",
                    CreationDate = "19.06.2023"
                };

                // Act
                unitToTest.Create(entity);

                // Assert

                Assert.Equal(1, db.Playlists.ToList().Count());
                Assert.Equal("Test Playlist 1", db.Playlists.ToList().ElementAt(0).Name);
                
            }
        }
       
    }
}
