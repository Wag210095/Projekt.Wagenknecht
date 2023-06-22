using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Project1.Context;
using Project1.Dtos;
using Project1.Helpers;
using Project1.Interfaces;
using Project1.Models;
using Project1.Repository;
using Project1.Services;
using Project1.Test.Helpers;
using Project1.Test.Mock;
using Xunit;




namespace Project1.Test
{
    public class SongServiceTest
    {

        private SongSerivce InitUnitToTest(ProjectDbContext db)
        {
            return new SongSerivce(
                new SongRepository(db),
                new RepositoryBase<SongModel>(db),
                new CategoryService(
                    new RepositoryBase<CategoryModel>(db),
                    new DateTimeServiceMock()),
                new DateTimeServiceMock()
                );
         
          
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
        public void AddSong_Success_Test()
        {
            using (ProjectDbContext db = new ProjectDbContext(GenerateDbOptions()))
            {
                SongSerivce unitToTest = InitUnitToTest(db);

                DatabaseUtilities.InitializeDatabase(db);

                NewSongDto entity = new NewSongDto()
                {
                    Title = "TestTITEL",
                    Duration = "3:21",
                    ReleaseYear = "2023",
                    Album = "XY",
                    Artist = "AB",
                    CategoryId = 1
                };

                // Act
                unitToTest.Create(entity);

                // Assert

                Assert.Equal(1, db.Songs.ToList().Count());
                Assert.Equal("TestTITEL", db.Songs.ToList().ElementAt(0).Title);
            }
        }
    }
}
