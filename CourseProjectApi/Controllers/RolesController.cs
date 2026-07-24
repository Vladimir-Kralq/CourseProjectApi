using CourseProjectApi.Data;
using CourseProjectApi.Dtos;
using CourseProjectApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public RolesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _db.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null) return NotFound();
            return role;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RoleDto updated)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null) return NotFound();

            role.Name = updated.Name;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null) return NotFound();

            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}