using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotionPictureController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MotionPictureController> _logger;

        public MotionPictureController(ILogger<MotionPictureController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MotionPicture> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new MotionPicture
            {
                ID = index,
                Name = Summaries[rng.Next(Summaries.Length)],
                ReleaseYear = DateTime.Now.AddDays(index).Year,
                Description = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
