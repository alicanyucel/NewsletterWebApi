using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newsletter.BackendApi.Models;
using Newsletter.BackendApi.Result;

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
            newsLetter.CreateDate = DateTime.Now;
            await _context.Newsletters.AddAsync(newsLetter);
            await _context.SaveChangesAsync();
            var results = new ResultModel()
            {
                Message = "ekleme işlemi başarılı"
            };
            return Ok(results);
        }
        [HttpPut]
        public async Task<IActionResult> Put(NewsLetter newsLetter)
        {
            _context.Newsletters.Update(newsLetter);
            await _context.SaveChangesAsync();
            var result = new ResultModel()
            {
                Message = "guncelleme işlemi nbaşarılı"
            };
            return Ok(result);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Newsletters.FindAsync(id);
            _context.Newsletters.Remove(result);
            await _context.SaveChangesAsync();
            var resultmodel = new ResultModel()
            {
                Message = "silme işlemi nbaşarılı"
            };
            return Ok(resultmodel);
          

        }
    }
}