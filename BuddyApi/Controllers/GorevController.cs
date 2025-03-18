using BuddyApi.Data;
using BuddyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuddyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GorevController : ControllerBase
    {

        private readonly AppDbContext _context;

        public GorevController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gorev>>> GetTasks()
        {
            return await _context.Gorevler.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gorev>> GetTask(int id)
        {
            var task = await _context.Gorevler.FindAsync(id);
            if (task == null)
                return NotFound();

            return task;
        }

        [HttpPost]
        public async Task<ActionResult<Gorev>> CreateTask(Gorev task)
        {
            _context.Gorevler.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Gorev task)
        {
            if (id != task.Id)
                return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Gorevler.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Gorevler.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
