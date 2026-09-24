using Microsoft.AspNetCore.Mvc;
using WebAppRemoteAccess.Models;
using WebAppRemoteAccess.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppRemoteAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var people = await new PersonData().GetPeople();
            return people;
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task Post([FromBody] Person value)
        {
            var pd = new PersonData();
            await pd.SavePerson(value);
        }
    }
}
