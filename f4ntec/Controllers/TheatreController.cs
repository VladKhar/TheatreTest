using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using f4ntec.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace f4ntec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheatreController : ControllerBase
    {

        private readonly ILogger<TheatreController> _logger;

        public TheatreController(ILogger<TheatreController> logger)
        {
            _logger = logger;
        }

        [HttpGet("~/GetPerformances")]
        public IEnumerable<Spectacle> GetPerformances()
        {
            DateTime curentDate = DateTime.Now;
            return Enumerable.Range(1, 5).Select(index => new Spectacle
            {
                Id = index,
                Name = "name"+index,
                AvailableTickets = index*10,
                StartDataTime = curentDate.AddHours(index),
                EndDataTime = curentDate.AddHours(index*1.5)
            })
            .ToArray();
        }

        [HttpPost]
        public void CreateSpectacle([FromForm]SpectacleCreateDto spectacle)
        {

        }

    }
}
