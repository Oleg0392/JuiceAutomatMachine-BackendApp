using Microsoft.AspNetCore.Mvc;
using JuiceAutomatMachine.Models;

namespace JuiceAutomatMachine.Controllers
{
    public class CoinsController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Index()
        {
            Coin[] coins = new Coin[]
            {
                new Coin(0, 10, false),
                new Coin(1, 5, true),
                new Coin(2, 2, false),
                new Coin(3, 1, false)
            };

            return Json(coins);
        }
    }
}
