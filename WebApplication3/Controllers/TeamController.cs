using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TeamController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Team> teams = new List<Team>();

            using (var client = new HttpClient())
            {
                using (var request = await client
                    .GetAsync("http://localhost:5134/api/Team/getTeams"))
                {
                    var result = await request.Content.ReadAsStringAsync();

                    teams = JsonConvert.DeserializeObject<List<Team>>(result);
                }
            }

            return View(teams);
        }
    }
}
