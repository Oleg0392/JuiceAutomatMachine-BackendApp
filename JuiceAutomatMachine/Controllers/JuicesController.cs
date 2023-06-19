using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JuiceAutomatMachine.Models;
using Newtonsoft.Json;
using JuiceAutomatMachine.Data;
using Microsoft.EntityFrameworkCore;

namespace JuiceAutomatMachine.Controllers
{
     
    public class JuicesController : Controller
    {
        private readonly JuiceDbContext _context;
        
        public JuicesController(JuiceDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            return Json(_context.Juices);
        }

        [HttpOptions]
        public dynamic Post()
        {
            return Ok();
        }
#pragma warning disable CS8602  // Разыменование вероятной пустой ссылки.
#pragma warning disable CS8604

        [HttpPost]
        [Route("api/[controller]")]
        public dynamic Post([FromBody]object? model)
        {
            if (model == null) return BadRequest();
            var juices = JsonConvert.DeserializeObject<Juice[]>(model.ToString());
            bool needToSave = false;

            if (_context.Juices.Count() > juices.Length)
            {
                for (int i = 0; i < _context.Juices.Count(); i++)
                {
                    IEnumerable<Juice> exists = juices.Where(j => j.JuiceId == _context.Juices.ElementAt(i).JuiceId);
                    if (exists.Any()) continue;
                    _context.Juices.Remove(_context.Juices.ElementAt(i));
                    needToSave = true;
                }
                if (needToSave) _context.SaveChangesAsync();
            }

            if (_context.Juices.Count() < juices.Length)
            {
                for (int i = 0; i < juices.Length; i++)
                {
                    IEnumerable<Juice> exists = _context.Juices.Where(j => j.JuiceId == juices[i].JuiceId);
                    if (exists.Any()) continue;
                    _context.Juices.Add(juices[i]);
                    needToSave = true;
                }
                if (needToSave) _context.SaveChangesAsync();
            }

            needToSave = false;

            for (int i = 0; i < _context.Juices.Count(); i++)
            {                            
                IEnumerable<Juice> differents = _context.Juices.AsNoTracking().Where(j => j.JuiceId == juices[i].JuiceId &&
                    (
                    j.Title != juices[i].Title ||
                    j.Price != juices[i].Price ||
                    j.Rest != juices[i].Rest
                    )
                );
                if (differents.Any())
                {
                    _context.Entry(juices[i]).State = EntityState.Modified;
                }             
            }
            _context.SaveChangesAsync();           

            return Ok(juices);
        }
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning restore CS8604

    }
}