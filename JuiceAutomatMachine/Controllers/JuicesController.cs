//using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using JuiceAutomatMachine.Models;
using Newtonsoft.Json;

namespace JuiceAutomatMachine.Controllers
{
     
    public class JuicesController : Controller
    {
        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult Get()
        {
            Juice[] juices = new Juice[]
            {
                new Juice(0, "Кленовый сауэр", 25, 15, "drink1.png"),
                new Juice(1, "Манхэттен", 15, 5, "drink2.png"),
                new Juice(2, "Карибское сокровище", 10, 10, "drink3.png"),
                new Juice(3, "Мохито", 30, 3, "drink4.png"),
                new Juice(4, "Кровавая Мэри", 20, 7, "drink5.png"),
                new Juice(5, "Японский урожай", 18, 9, "drink6.png"),
                new Juice(6, "Сказка", 35, 1, "drink7.png"),
                new Juice(7, "Пача Ибица", 40, 12, "drink8.png")
            };
            return Json(juices);
        }

        [HttpOptions]
        public dynamic Post()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("api/[controller]")]
        public dynamic Post([FromBody]object? model)
        {
            if (model == null) return BadRequest();
            var juices = JsonConvert.DeserializeObject<Juice[]>(model.ToString());
            return Ok(juices);
        }
    }
}