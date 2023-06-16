using Microsoft.AspNetCore.Mvc;
using JuiceAutomatMachine.Data;
using JuiceAutomatMachine.Models;
using Newtonsoft.Json;

namespace JuiceAutomatMachine.Controllers
{
    public class CoinsController : Controller
    {
        private readonly CoinDbContext _context;

        public CoinsController(CoinDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Index()
        {
            return Json(_context.Coins);
        }

        [HttpOptions]
        public dynamic Post()
        {
            return Ok();
        }

#pragma warning disable CS8604
        [HttpPost]
        [Route("api/[controller]")]
        public dynamic Post([FromBody]object? model)
        {
            if (model == null) return BadRequest();
            var coins = JsonConvert.DeserializeObject<Coin[]>(model.ToString());
            return Ok(coins);
        }
#pragma warning restore CS8604
    }
}
