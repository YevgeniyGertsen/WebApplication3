using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("Atr/Hotel/Rooms")]
    public class RoomController : Controller
    {
        /// <summary>
        /// rooms → Показать все номера
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [Route("Index")]
        [Route("All")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomDetails(int roomId)
        {
            return View();
        }

        /// <summary>
        /// rooms?category=luxury → Показать номера категории "люкс"
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("category/{category=standart}")]
        public IActionResult RoomList(string category)
        {
            return View();
        }    
        
        public IActionResult RoomList(string category, int capacity)
        {
            return View();
        }
    }
}
