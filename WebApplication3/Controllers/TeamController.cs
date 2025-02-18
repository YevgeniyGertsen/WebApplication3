using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TeamController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            List<TeamViewModel> teams = new List<TeamViewModel>();

            TeamViewModel team = new TeamViewModel();
            team.ImagePath = "~/img/team/1.jpg";
            team.FullName = "Kety Pery";
            team.Position = "Singer";
            team.Description = "Lorem ipsupm dolor sit amet, conse ctetur adipisicing elit, sed do eiumthgtipsupm dolor sit amet conse";

            team.TeamLinks = new List<TeamLink>()
            {
                new TeamLink(){URL="https://www.facebook.com/", LinkType="zmdi-facebook" },
                new TeamLink(){URL="https://twitter.com/", LinkType="zmdi-twitter" },
                new TeamLink(){URL="https://www.pinterest.com/", LinkType="zmdi-pinterest" }
            }; 

            teams.Add(team);

            //var teams = GetTeamsFromDb();

            return View(teams);
        }
    }
}
