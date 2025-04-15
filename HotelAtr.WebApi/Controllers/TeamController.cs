using HotelAtr.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAtr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TeamController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("getTeams")]
        public async Task<List<Team>> getTeams()
        {
            return await _db.Teams
                            .Include(p => p.Position)
                            .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Team team,
            IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var memory = new MemoryStream();
                    await file.CopyToAsync(memory);
                    team.ImageTeam = memory.ToArray();
                }

                team.CreatedBy = "admin";
                team.CreatedAt = DateTime.Now;

                _db.Teams.Add(team);
                await _db.SaveChangesAsync();

                return Ok(new { message = "Сотрудник успешно добавлен" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
