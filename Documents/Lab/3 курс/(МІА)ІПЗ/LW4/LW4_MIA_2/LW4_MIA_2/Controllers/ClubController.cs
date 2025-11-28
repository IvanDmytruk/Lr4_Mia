using LW4_MIA_2.Data;
using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
namespace LW4_MIA_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly IRepositoriesClub _repository;

        public ClubController(IRepositoriesClub repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var club = await _repository.GetByIdAsync(id);
            return club == null ? NotFound("Клуб не знайдено") : Ok(club);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Club club)
        {
            if (!club.Validate())
                return BadRequest("Некоректні дані клубу");

            string pattern = @"(^\+380\d{9}$)|(^[^@\s]+@[^@\s]+\.[^@\s]+$)";
            if (!string.IsNullOrWhiteSpace(club.Contacts) && !Regex.IsMatch(club.Contacts, pattern))
            return BadRequest("Контакти мають бути у форматі +380XXXXXXXXX або email");
            await _repository.CreateAsync(club);
            return CreatedAtAction(nameof(GetById), new { id = club.Id }, club);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Club updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound("Клуб не знайдено");

            await _repository.UpdateAsync(id, updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound("Клуб не знайдено");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
