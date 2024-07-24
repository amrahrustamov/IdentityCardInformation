using İdentityCardİnformation.Database;
using İdentityCardİnformation.Database.Models;
using İdentityCardİnformation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace İdentityCardİnformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDataDbContext _dbContext;
        private readonly IUserService _userService;

        public UserController(UserDataDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (String.IsNullOrEmpty(user.FirstName))
            {
                return BadRequest(new { message = "FirstName needs to entered" });
            }
            if (String.IsNullOrEmpty(user.LastName))
            {
                return BadRequest(new { message = "LastName needs to entered" });
            }
            if (String.IsNullOrEmpty(user.FatherName))
            {
                return BadRequest(new { message = "FatherName needs to entered" });
            }
            if (String.IsNullOrEmpty(user.BirthDate))
            {
                return BadRequest(new { message = "BirthDate needs to entered" });
            }
            if (String.IsNullOrEmpty(user.BirthPlace))
            {
                return BadRequest(new { message = "BirthPlace needs to entered" });
            }
            if (String.IsNullOrEmpty(user.IdentityNumber))
            {
                return BadRequest(new { message = "IdentityNumber needs to entered" });
            }

            User userToRegister = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FatherName = user.FatherName,
                BirthDate = user.BirthDate,
                BirthPlace = user.BirthPlace,
                IdentityNumber = user.IdentityNumber
            };


            if(_userService.CheckIdentityNumber(userToRegister.IdentityNumber))
            {
                _dbContext.users.Add(userToRegister);
                await _dbContext.SaveChangesAsync();
                return Ok(new { message = "User registration successful" });
            }

            return BadRequest(new { message = "User registration unsuccessful" });
        }
        [HttpGet("UserInfo/{code}")]
        public async Task<IActionResult> GetUser(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                return BadRequest(new { message = "IdentityNumber needs to entered" });
            }
            var user = _dbContext.users.FirstOrDefault(x => x.IdentityNumber == code);

            if (user == null) return NotFound(new { message = "User not found" });

            UserViewModel data = new UserViewModel(user.FirstName, user.LastName, user.FatherName, user.BirthPlace, user.BirthDate);

            return Ok(data);
        }
    }
}
