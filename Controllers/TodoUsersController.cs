using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_new_app.Models;

namespace my_new_app.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TodoUsersController : ControllerBase {
        private readonly TodoContext _context;

        public TodoUsersController (TodoContext context) {
            _context = context;
        }

        // GET: api/TodoUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoUser>>> GetTodoUsers () {
            return await _context.TodoUsers.ToListAsync ();
        }

        // GET: api/TodoUsers/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<TodoUser>> GetTodoUser (int id) {
            var todoUser = await _context.TodoUsers.FindAsync (id);

            if (todoUser == null) {
                return NotFound ();
            }

            return todoUser;
        }

        // PUT: api/TodoUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutTodoUser (int id, TodoUser todoUser) {
            if (id != todoUser.id) {
                return BadRequest ();
            }

            _context.Entry (todoUser).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) {
                if (!TodoUserExists (id)) {
                    return NotFound ();
                } else {
                    throw;
                }
            }

            return NoContent ();
        }

        // POST: api/TodoUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoUser>> PostTodoUser (TodoUser todoUser) {
            _context.TodoUsers.Add (todoUser);
            await _context.SaveChangesAsync ();

            //return CreatedAtAction("GetTodoUser", new { id = todoUser.Id }, todoUser);
            return CreatedAtAction (nameof (GetTodoUser), new { id = todoUser.id }, todoUser);
        }

        // DELETE: api/TodoUsers/5
        [HttpDelete ("{id}")]
        public async Task<ActionResult<TodoUser>> DeleteTodoUser (int id) {
            var todoUser = await _context.TodoUsers.FindAsync (id);
            if (todoUser == null) {
                return NotFound ();
            }

            _context.TodoUsers.Remove (todoUser);
            await _context.SaveChangesAsync ();

            return todoUser;
        }

        private bool TodoUserExists (int id) {
            return _context.TodoUsers.Any (e => e.id == id);
        }
    }
}