using API_EntityFramework.Data;
using API_EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(ContextDatabase context) : Controller
    {
        private readonly ContextDatabase _context = context;

        //User

        [HttpGet]
        [Route("api/users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await context.Users.ToListAsync();
            return Ok(users);
        }


        [HttpGet]
        [Route("api/user/firstname/{firstname}")]
        public async Task<ActionResult<User?>> GetUserByFirstName(string firstname)
        {
            // Check if the param is there
            if (string.IsNullOrEmpty(firstname)) return BadRequest("Name is required.");

            // Search in database
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.FirstName == firstname);

            return user != null ? Ok(user) : NotFound("User not found");
        }


        [HttpGet]
        [Route("api/user/lastname/{lastname}")]
        public async Task<ActionResult<User?>> GetUserByLastName(string lastname)
        {
            // Check if the param is there
            if (string.IsNullOrEmpty(lastname)) return BadRequest("Name is required.");

            // Search in database
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.FirstName == lastname);

            return user != null ? Ok(user) : NotFound("User not found");
        }



        //Adress

        [HttpGet]
        [Route("api/adress")]
        public async Task<ActionResult<IEnumerable<Address>>> GetAdress()
        {
            IEnumerable<Address> adresses = await context.Addresses.ToListAsync();
            return Ok(adresses);
        }

        










        //QUERY



        //[HttpGet]
        //[Route("api/users/search")]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsersByAge([FromQuery] int? age)
        //{
        //    if (age == null) return BadRequest("Age is required.");

        //    IEnumerable<User> users = await _context.Users.Where(u => u.Age == age).ToListAsync();
        //    return users.Any() ? Ok(users) : NotFound("No users found with the specified age.");
        //}
    }
}
