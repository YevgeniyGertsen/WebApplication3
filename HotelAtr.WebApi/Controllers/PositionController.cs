using HotelAtr.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HotelAtr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PositionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("getAllPosition")]
        public async Task<List<Position>> getAllPosition()
        {
            return await _db.Positions.ToListAsync();
        }

        [HttpGet("getPostionById/{Id:int}")]
        public async Task<Position> getPostionById(int Id)
        {
            return await _db.Positions
                .FirstOrDefaultAsync(f=>f.Id==Id);
        }


        [HttpPost("createPosition")]
        public async Task<IActionResult> createPosition(Position position)
        {
            try
            {
                _db.Positions.Add(position);
                await _db.SaveChangesAsync();

                return Ok(new { message = "Должность успешно добавлена"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("createPosition2")]
        public async Task<IActionResult> createPosition2([FromForm]Position position)
        {
            try
            {
                _db.Positions.Add(position);
                await _db.SaveChangesAsync();

                return Ok(new { message = "Должность успешно добавлена" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var data = await _db.Positions.FirstOrDefaultAsync(f => f.Id == Id);
                if (data != null)
                {
                    _db.Positions.Remove(data);
                    await _db.SaveChangesAsync();
                    return Ok(new { message = "Должность успешно удалена" });
                }
                else
                {
                    return NotFound(new { message = "Должность не найдена" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }            
        }

    }
}