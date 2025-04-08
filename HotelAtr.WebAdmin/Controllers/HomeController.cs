using HotelAtr.WebAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelAtr.WebAdmin.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _db;

		public HomeController(ILogger<HomeController> logger,
			AppDbContext db)
		{
			_logger = logger;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		//SELECT - GET
		public IActionResult Position()
		{
			var positions = _db.Positions.ToList();

			return View(positions);
		}

		public IActionResult EditPosition(int id)
		{
			if (id != 0)
			{
				var position = _db.Positions.Find(id);

				return View(position);
			}
			else
			{
				return View(new Position());
			}
		}

		[HttpPost]
		public IActionResult EditPosition(Position position)
		{
			if (position.Id != 0)
			{
				var _position = _db.Positions.Find(position.Id);
				_position.Name = position.Name;
				_position.Description = position.Description;

				_db.SaveChanges();
			}
			else
			{
				position.CreatedBy = "admin";
				position.CreatedAt = DateTime.Now;
				_db.Positions.Add(position);
				_db.SaveChanges();
			}

			return RedirectToAction("Position", "Home");
		}

		public IActionResult DeletePosition(int id)
		{
			var _position = _db.Positions.Find(id);
			if(_position!=null)
			{
				_db.Positions.Remove(_position);
				_db.SaveChanges();
			}

			return RedirectToAction("Position", "Home");
		}
	}
}
