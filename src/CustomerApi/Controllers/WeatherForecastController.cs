using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerApi;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherForecastController()
        {

        }


        [HttpGet("home")]
        public IEnumerable<WeatherForecast> Home()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
                .ToArray();
        }
        [HttpGet("city")]
        public ActionResult<string> City()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return "Melbourne";
        }

        [HttpGet("country")]
        public ActionResult<string> Country()
        {
            var rng = new Random().Next(1, 10);

            if (rng > 5)
            {
                return Unauthorized();
            }
            return "Australia";
        }
    }
}