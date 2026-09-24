using SQLite;
using MauiDataAccess.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MauiDataAccess.DataAccess
{
    // Ensure there is only one definition of PersonData in this namespace
    public class PersonData
    {
        public async Task<List<Person>> GetPeopleAsync()
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                List<Person> people = new List<Person>();
                var response = await client.GetAsync("http://localhost:4928/api/Person");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(content);
                        if (deserializedPeople != null)
                        {
                            people = deserializedPeople;
                        }
                    }
                }

                return people;
            }
            catch (Exception)
            {
                // Fix for CS0168 and IDE0059: Removed unused variable 'ex'.
                throw;
            }
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                var content = JsonConvert.SerializeObject(person);
                var buff = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buff);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:4928/api/Person", byteContent);

                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception)
            {
                // Fix for CS0168 and IDE0059: Removed unused variable 'ex'.
                throw;
            }
        }
    }
}
