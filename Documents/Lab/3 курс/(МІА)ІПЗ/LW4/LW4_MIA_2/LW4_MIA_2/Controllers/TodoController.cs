using LW4_MIA_2.Data;
using LW4_MIA_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LW4_MIA_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok(InMemoryDatabase.Todos);

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var todo = InMemoryDatabase.Todos.FirstOrDefault(t => t.Id == id.ToString());
            return todo == null ? NotFound("Завдання не знайдено") : Ok(todo);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Todo todo)
        {
            if (!todo.Validate())
            return BadRequest("Некоректні дані завдання");
            InMemoryDatabase.Todos.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Todo updated)
        {
            var todo = InMemoryDatabase.Todos.FirstOrDefault(t => t.Id == id.ToString());
            if (todo == null) return NotFound("Завдання не знайдено");

            if (!updated.Validate())
                return BadRequest("Некоректні дані");

            todo.Name = updated.Name;
            todo.IsComplete = updated.IsComplete;
            return Ok(todo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var todo = InMemoryDatabase.Todos.FirstOrDefault(t => t.Id == id.ToString());
            if (todo == null) return NotFound("Завдання не знайдено");

            InMemoryDatabase.Todos.Remove(todo);
            return NoContent();
        }
    }
}
