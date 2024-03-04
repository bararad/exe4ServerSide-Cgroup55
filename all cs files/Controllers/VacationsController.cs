using Microsoft.AspNetCore.Mvc;
using TarHome1.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TarHome1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        // GET: api/<VacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            return Vacation.Read();
        }


        // POST api/<VacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation v)
        {
            return v.Insert();
        }
       

        // GET api/<VacationsController>/5
        [HttpGet("{email}")]
        public IEnumerable<Vacation> Get(string email)
        {
            Vacation vaca = new Vacation();

            return vaca.ReadByUserEmail(email);
        }


        // PUT api/<VacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VacationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
