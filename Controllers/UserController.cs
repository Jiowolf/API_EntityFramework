using API_EntityFramework.Data;
using API_EntityFramework.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ContextDatabase context, ILogger<UserController> logger) : ControllerBase
    {
        private readonly ContextDatabase _context = context;
        private readonly ILogger<UserController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                IEnumerable<User> users = await _context.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex){
                _logger.LogError(ex, "Error in GetUsers");
                return StatusCode(500, "An error occurred while retrieving users.");
            }
        }
    }
}
