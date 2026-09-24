using SQLite;
using WebAppRemoteAccess.Models;
using System.Collections.ObjectModel;

namespace WebAppRemoteAccess.DataAccess
{
    // Ensure there is only one definition of PersonData in this namespace
    public class PersonData
    {
        SQLiteAsyncConnection database = null!; // Marked as non-nullable but initialized later

        async Task Init()
        {
            if (database is not null)
            {
                return;
            }
            database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            await database.CreateTableAsync<Person>();
        }

        public async Task<ObservableCollection<Person>> GetPeople()
        {
            await Init();
            var people = await database.Table<Person>().ToListAsync();
            return new ObservableCollection<Person>(people);
        }

        public async Task SavePerson(Person person)
        {
            await Init();
            if (person.ID != 0)
            {
                // Update an existing person
                await database.UpdateAsync(person);
            }
            else
            {
                // Save a new person
                await database.InsertAsync(person);
            }
        }
    }
}
