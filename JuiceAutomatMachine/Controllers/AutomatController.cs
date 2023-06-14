using Microsoft.AspNetCore.Mvc;

namespace JuiceAutomatMachine.Controllers
{
    public class AutomatController : Controller
    {
        [HttpGet]
        [Route("[controller]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
