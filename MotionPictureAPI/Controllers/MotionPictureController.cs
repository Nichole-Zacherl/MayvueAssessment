using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotionPictureAPI.DAO;

namespace MotionPictureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotionPictureController : ControllerBase
    {
        private readonly ILogger<MotionPictureController> _logger;
        private readonly IMotionPictureDAO _motionPictureDAO;

        public MotionPictureController(ILogger<MotionPictureController> logger, IMotionPictureDAO motionPictureDAO)
        {
            _logger = logger;
            this._motionPictureDAO = motionPictureDAO;
        }

        [HttpGet]
        //public async Task<IEnumerable<MotionPicture>> Get()   
        public async Task<List<MotionPicture>> GetAll()
        {
            return await _motionPictureDAO.GetAll();
        }

        [HttpPost]
        public async Task<bool> Create(MotionPicture motionPicture)
        {
            return await _motionPictureDAO.Create(motionPicture);
        }

        [HttpPost("copy/{id}")]
        public async Task<bool> Copy(int id)
        {
            return await _motionPictureDAO.Copy(id);
        }

        [HttpPut]
        public async Task<bool> Put(MotionPicture motionPicture)
        {
            return await _motionPictureDAO.Update(motionPicture);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _motionPictureDAO.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unable to Delete");
                return Problem("An unexpected error occurred", statusCode: 500);
            }
        }

    }
}
