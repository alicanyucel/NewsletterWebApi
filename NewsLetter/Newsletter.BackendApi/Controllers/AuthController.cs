using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newsletter.BackendApi.Dtos;
using Newsletter.BackendApi.Models;

namespace Newsletter.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ContextDb _context;
        public AuthController(ContextDb contextDb)
        {
            _context = contextDb;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var IsUserNameExits = await _context.Users.Where(p => p.UserName == registerDto.UserName).FirstOrDefaultAsync();
            if (IsUserNameExits != null)
            {
                return BadRequest("bu kullanici daha önce alınmış.");
            };
            var IsEmailExits = await _context.Users.Where(p => p.Email == registerDto.EmailAddress).FirstOrDefaultAsync();
            if (IsEmailExits != null)
            {
                return BadRequest("bu email adresi daha önce alınmış.");
            };
            User user = new()
            {
                Email = registerDto.EmailAddress,
                Password = registerDto.Password,
                NameLastName = registerDto.NameLastName,
                UserName = registerDto.UserName,

            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("kayit işlemi başarılı.");
        }
    }
}
