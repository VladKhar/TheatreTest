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
        private static IList<Spectacle> spectacles;

        static TheatreController()
        {
            DateTime curentDate = DateTime.Now;
            spectacles = Enumerable.Range(1, 5).Select(index => new Spectacle
            {
                Id = index,
                Name = "name" + index,
                AvailableTickets = index * 10,
                StartDateTime = curentDate.AddHours(index),
                Duration = curentDate.AddHours(index * 1.5) - curentDate.AddHours(index)
            }).ToList();
        }


        public TheatreController(ILogger<TheatreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Spectacle> GetPerformances()
        {
            return spectacles;
        }

        [HttpGet("{id}")]
        public Spectacle GetPerformance(int id)
        {
            return spectacles.Single(s => s.Id == id);
        }

        [HttpPost]
        public IActionResult CreatePerformance([FromBody]SpectacleCreateDto spectacleDto)
        {
            var newId = spectacles.Count + 1;

            var spectacle = new Spectacle()
            {
                Id = newId,
                Name = spectacleDto.Name,
                AvailableTickets = spectacleDto.AvailableTickets,
                StartDateTime = spectacleDto.StartDateTime,
                Duration = TimeSpan.Parse(spectacleDto.Duration)
            };
            spectacles.Add(spectacle);

            return CreatedAtAction(nameof(GetPerformance), new {id = newId}, spectacle);
        }

    }
}
