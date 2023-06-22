using Project1.Context;

namespace Project1.Test.Helpers
{
    public static class DatabaseUtilities
    {

        public static void InitializeDatabase(ProjectDbContext db)
        {
            db.Database.EnsureCreated();

        }



    }
}
