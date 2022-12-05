using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newsletter.BackendApi.Models;

namespace Newsletter.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        private readonly ContextDb _context;
        public NewsLetterController(ContextDb context)
        {
            _context = context;

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _context.Newsletters.FindAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Newsletters.ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(NewsLetter newsLetter)
        {
            await _context.Newsletters.AddAsync(newsLetter);
            await _context.SaveChangesAsync();
            return Ok("kayıt eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(NewsLetter newsLetter)
        {
            _context.Newsletters.Update(newsLetter);
            await _context.SaveChangesAsync();
            return Ok("kayıt güncellendi");

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Newsletters.FindAsync(id);
            _context.Newsletters.Remove(result);
            await _context.SaveChangesAsync();
            return Ok("kayıt silindi");

        }
    }
}