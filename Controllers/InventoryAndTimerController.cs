using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Counter.Model;
using Counter.Service;
using System.Threading.Tasks;

namespace Counter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryAndTimerController : ControllerBase
    {
        private List<Item> Items = new List<Item>();
        private static readonly int TimerCount = 10;

        private readonly ILogger<InventoryAndTimerController> _logger;

        public InventoryAndTimerController(ILogger<InventoryAndTimerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetTimer")]
        public int GetTimer()
        {
            return TimerCount;
        }

        [HttpGet("GetInventory")]
        public List<Item> GetInventory()
        {
            InventoryService inventory = new InventoryService();
            Items = inventory.LoadJson();
            return Items;
        }
    }
}
