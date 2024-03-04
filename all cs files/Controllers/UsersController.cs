using Microsoft.AspNetCore.Mvc;
using TarHome1.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TarHome1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User u = new User();
            return u.Read();
        }


        //POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User u)
        {
            return u.Register();
        }

        //Put api/<UsersController>/email
        [HttpPut]
        public int Put([FromBody] User user)
        {
            return user.UpdateDetails(user.Email);
        }

        //Put api/<UsersController>/email
        [HttpPut("byAdmin")]
        public int AdminPut([FromBody] User user)
        {
            return user.AdminUpdateDetails(user.Email);
        }

        [HttpPost("Login")]
        public User GetUserNameandPassword([FromBody] User user)
        {
            User u = user.Login();
            return u;
        }

        //Get report from DB by month
        [HttpGet("month")]
        public Object getReport(int month)
        {
            User u = new User();
            return u.GetReport(month);
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // DELETE api/<UsersController>/5
        [HttpDelete()]
        public int Delete([FromBody] User user)
        {
            User u=new User();
            return u.DeleteUser(user);
        }
    }
}
