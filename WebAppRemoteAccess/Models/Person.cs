using SQLite;

namespace WebAppRemoteAccess.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty; // Default value added
        public string LastName { get; set; } = string.Empty;  // Default value added
        public DateTime DoB { get; set; }
    }
}
