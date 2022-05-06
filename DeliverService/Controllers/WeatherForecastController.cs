using DeliverService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFreeSql _fsql;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFreeSql fsql)
        {
            _logger = logger;
            _fsql = fsql;
        }

        [HttpGet]
        public Object Get()
        {
            var blogs = _fsql.Select<Test>()
                        .Where(b => b.Id > 1)
                        .OrderBy(b => b.name) 
                        .Limit(10) //第100行-110行的记录
                        .ToList();
            return blogs;
        
        }


    }
}
