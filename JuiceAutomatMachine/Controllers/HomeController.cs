using Microsoft.AspNetCore.Mvc;

namespace JuiceAutomatMachine.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("[controller]")]
        public string Index()
        {
            return "Juice Automat emulator test task (Backend App) started.";
        }
    }
}
