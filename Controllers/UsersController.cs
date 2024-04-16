using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userId = await _userService.GetById(id);
            return Ok(userId);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var createdUser = await _userService.PostUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            var newUser = await _userService.PutUser(id, user);

            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            if (await _userService.GetById(id) == null)
            {
                return NotFound("User not found");
            }
            _userService.DeleteUser(id);
            return Ok("Deleted user with Id: " + id);//
        }

    }
}
