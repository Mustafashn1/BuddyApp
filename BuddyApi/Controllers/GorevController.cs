using BuddyApi.Data;
using BuddyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Serilog;

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Gorevler.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            try
            {
                _context.Gorevler.Remove(task);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Hata loglama (Örneğin, bir logger ile)
                Log.Error(ex, "Task deletion failed for ID {TaskId}", id);

                // Kendi hata mesajınızı döndürebilir veya genel bir hata mesajı verebilirsiniz.
                return StatusCode(500, "An error occurred while deleting the task.");
            }
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTask(int id)
        //{
        //    var task = await _context.Gorevler.FindAsync(id);
        //    if (task == null)
        //        return NotFound();

        //    _context.Gorevler.Remove(task);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return NoContent();
        //}
    }
}
