using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.src.Configurations;
using WebApplication6.src.Entities;
using WebApplication6.src.Features.Authorization.Dto;

namespace WebApplication6.src.Features.Authorization.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly MySqlDbContext _database;

        public UsersController(MySqlDbContext database)
        {
            _database = database;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _database.Users.AsNoTracking().ToListAsync());
        }
        [HttpGet("alldef")]
        public IActionResult GetUsersDef()
        {
            return Ok(1);
        }

        [HttpPost("user")]
        public async Task<ActionResult> AddNewUser(UserCreateDto dto) {
            var user = new User(dto.Login, dto.Password);
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
            
            return Ok();
        }

        [HttpGet("user")]
        public async Task<ActionResult> GetUser(string login, string password)
        {
            //var isUser = await _database.Users.Where(record => record.Login == login).AsNoTracking().FirstOrDefaultAsync();
            //if(isUser == null)
            //{
            //    return BadRequest("Incorect Login");
            //}
            //if(isUser.Password != password)
            //{
            //    return BadRequest("Incorect Password");

            //}
            Console.WriteLine("Fewfwefwefwef", 3132);
            var user = new User("fewf1", "FEWFWE");
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
            return Ok();
        }
    }
}
