using LW4_MIA_2.Data;
using LW4_MIA_2.Models;
using LW4_MIA_2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace LW4_MIA_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepositoriesUser _userRepository;

        public UserController(IRepositoriesUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _userRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? NotFound("Користувача не знайдено") : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (user == null) return BadRequest("Користувач не може бути null");
            if (!user.Validate()) return BadRequest("Некоректні дані користувача");

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(user.Email, pattern))
            return BadRequest("Email має неправильний формат");
            await _userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] User updated)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return NotFound("Користувача не знайдено");

            await _userRepository.UpdateAsync(id, updated);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null) return NotFound("Користувача не знайдено");

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
