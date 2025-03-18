using BuddyApi.Data;
using BuddyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuddyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanlamaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanlamaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planlama>>> GetTasks()
        {
            return await _context.Planlar.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planlama>> GetTask(int id)
        {
            var task = await _context.Planlar.FindAsync(id);
            if (task == null)
                return NotFound();

            return task;
        }

        [HttpPost]
        public async Task<ActionResult<Planlama>> CreateTask(Planlama task)
        {
            _context.Planlar.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Planlama task)
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
            var task = await _context.Planlar.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Planlar.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
