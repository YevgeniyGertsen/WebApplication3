using System.Runtime.InteropServices;

namespace WebApplication3.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
