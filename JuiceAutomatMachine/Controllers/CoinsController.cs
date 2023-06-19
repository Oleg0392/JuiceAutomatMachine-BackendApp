using Microsoft.AspNetCore.Mvc;
using JuiceAutomatMachine.Data;
using JuiceAutomatMachine.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

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
#pragma warning disable CS8602
        [HttpPost]
        [Route("api/[controller]")]
        public dynamic Post([FromBody]object? model)
        {
            if (model == null) return BadRequest();
            var coins = JsonConvert.DeserializeObject<Coin[]>(model.ToString());
            for (int i = 0; i < coins.Length; i++)
            {               
                IEnumerable<Coin> differents = _context.Coins.AsNoTracking().Where(c => c.CoinId == coins[i].CoinId && c.Blocked != coins[i].Blocked);
                if (differents.Any())
                {
                    _context.Entry(coins[i]).State = EntityState.Modified;
                }               
            }
            _context.SaveChangesAsync();
            return Ok(coins);
        }
#pragma warning restore CS8604
#pragma warning restore CS8602
    }
}
