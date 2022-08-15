using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            _motionPictureDAO = motionPictureDAO;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MotionPicture>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _motionPictureDAO.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to fetch motion picutres");
                return Problem("An unexpected error occurred", statusCode: 500);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(MotionPicture), 200)]
        public async Task<IActionResult> Create(MotionPicture motionPicture)
        {
            try
            {
                await _motionPictureDAO.Create(motionPicture);
                return StatusCode(StatusCodes.Status201Created, motionPicture);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to create motion picture");
                return Problem("An unexpected error occurred", statusCode: 500);
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Put(MotionPicture motionPicture)
        {
            try
            {
                var updated = await _motionPictureDAO.Update(motionPicture);
                if (updated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest($"Unable to locate motion picture {motionPicture.ID}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unable to update motion picure {motionPicture.ID}");
                return Problem("An unexpected error occurred", statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(202)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _motionPictureDAO.Delete(id);
                if (deleted)
                {
                    return Ok();
                }
                else
                {
                    // No error but nothing to delete
                    return Accepted();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unable to delete motion picure {id}");
                return Problem("An unexpected error occurred", statusCode: 500);
            }
        }
    }
}
