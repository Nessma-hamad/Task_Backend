using BL.AppServices;
using BL.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class JobPositionController : ControllerBase
    {
        private readonly JobPositionAppservice _jobPositionAppservice;

        public JobPositionController(JobPositionAppservice jobPositionAppservice)
        {
            _jobPositionAppservice = jobPositionAppservice;
        }
        [HttpGet]
       [AllowAnonymous]
        public ActionResult<IEnumerable<JobPositionDto>> GetJobPositions()
        {
            return _jobPositionAppservice.GetAllJobPositions();
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<JobPositionDto> GetJobPosition(int id)
        {
            var jobPositions = _jobPositionAppservice.GetJobPosition(id);

            if (jobPositions == null)
            {
                return NotFound();
            }

            return jobPositions;
        }
       [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutJobPosition(int id, JobPositionDto JobPositionDto)
        {
            try
            {
                _jobPositionAppservice.UpdateJobPosition(JobPositionDto, id);

                return Ok(JobPositionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<JobPositionDto> PostJobPosition(JobPositionDto JobPositionDto)
        {
            _jobPositionAppservice.CreateJobPosition(JobPositionDto);
            return CreatedAtAction("GetJobPositions", JobPositionDto);

        }
       [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteJobPosition(int id)
        {
            _jobPositionAppservice.DeleteJobPosition(id);
            return NoContent();
        }

        private bool JobPositionExists(int id)
        {
            return _jobPositionAppservice.CheckJobPositionExists(id);
        }


    }
}
