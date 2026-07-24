using CourseProjectApi.Data;
using CourseProjectApi.Dtos;
using CourseProjectApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CourseProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UserRolesController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        [HttpGet]
        public async Task<IEnumerable<UserRole>> GetAll()
        {
          
            return await _db.UserRoles
                .AsNoTracking()
                .ToListAsync();
        }

       
        [HttpPost]
        public async Task<ActionResult> Add(UserRole userRole)
        {
            var userExists = await _db.Users.AnyAsync(u => u.Id == userRole.UserId);
            var roleExists = await _db.Roles.AnyAsync(r => r.Id == userRole.RoleId);
            if (!userExists || !roleExists) return BadRequest("UserId или RoleId не съществува.");

            var exists = await _db.UserRoles.AnyAsync(x => x.UserId == userRole.UserId && x.RoleId == userRole.RoleId);
            if (exists) return Conflict("Тази връзка вече съществува.");

            var link = new UserRole
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };

            _db.UserRoles.Add(link);
            await _db.SaveChangesAsync();

            return Ok(link);
        }


        [HttpDelete] 
        public async Task<ActionResult> Remove(int userId, int roleId)
        {
            
            var link = await _db.UserRoles
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);

            if (link == null) return NotFound();

            _db.UserRoles.Remove(link);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("{UserId}")]
        public async Task<ActionResult<UserRole>> GetLinkByUserId(int UserId)
        {
            var link = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserId == UserId);
            if (link == null) return NotFound();
            return Ok(link);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateLink(int userId, UserRoleDto linkToUpdate)
        {
            var link = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            if (link == null) return NotFound();

            _db.UserRoles.Remove(link);
            await _db.SaveChangesAsync();

            var newLink = new UserRole
            {
                UserId = userId,
                RoleId = linkToUpdate.RoleId
            };

            _db.UserRoles.Add(newLink);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
