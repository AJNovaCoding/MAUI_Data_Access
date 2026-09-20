
namespace MauiDataAccess.Models
{
    public static class DatabaseConstants
    {
        public const string DatabaseFileName = "Person.db3";
        public const SQLite.SQLiteOpenFlags Flags =
           //open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite
           //create it if it doesn't exist
          | SQLite.SQLiteOpenFlags.Create
          //enable multi-threaded database access
          | SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

    }
}
