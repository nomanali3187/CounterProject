using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Counter.Model;
using System.Threading.Tasks;

namespace Counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimerCompletedController : ControllerBase
    {
        private readonly ILogger<TimerCompletedController> _logger;

        public TimerCompletedController(ILogger<TimerCompletedController> logger)
        {
            _logger = logger;
        }

        [HttpPost("TimerCompletedMessage")]
        public void TimerCompletedMessage([FromForm]string message)
        {
            var msg = message;
            Console.WriteLine(msg);
        }

    }
}
