using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;
using LW4_MIA_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LW4_MIA_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _services.GetCategoryAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _services.GetCategoryByIdAsync(id);
            return category == null ? NotFound("Категорію не знайдено") : Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            var validationErrors = category.Validate();
            if (validationErrors.Count > 0)
            return BadRequest("Некоректні дані категорії: " + string.Join("; ", validationErrors));
            await _services.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Category updated)
        {
            var existing = await _services.GetCategoryByIdAsync(id);
            if (existing == null) return NotFound("Категорію не знайдено");
            await _services.UpdateCategoryAsync(id, updated);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _services.GetCategoryByIdAsync(id);
            if (existing == null) return NotFound("Категорію не знайдено");
            await _services.DeleteCategoryAsync(id);
            return NoContent();
        }

    }
}