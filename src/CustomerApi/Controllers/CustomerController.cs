using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {


        //private readonly ILogger<WeatherForecastController> _logger;

        public CustomerController()
        {

        }

        [HttpGet("index")]
        public ActionResult<string> Index()
        {
            return "Sam foo";
        }

    }
}