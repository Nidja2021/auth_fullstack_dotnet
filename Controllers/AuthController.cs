using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObject) {
            if (userObject is null) {
                return BadRequest();
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Username == userObject.Username && x.Password == userObject.Password);
            if (user is null) {
                return NotFound(new { Message = "User Not Found" });
            }

            return Ok(new { Message = "Login Success" });
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userObject) {
            if (userObject is null) {
                return BadRequest();
            }

            await _context.Users.AddAsync(userObject);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Register Success" });
            
        }
    }
}