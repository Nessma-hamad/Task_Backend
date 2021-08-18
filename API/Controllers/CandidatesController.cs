using BL.AppServices;
using BL.DtoModels;
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
  
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateAppservice _CandidateAppservice;

        public CandidatesController(CandidateAppservice CandidateAppservice)
        {
            _CandidateAppservice = CandidateAppservice;
        }
        [HttpGet]
        // [AllowAnonymous]
        public ActionResult<IEnumerable<CandidateDto>> GetCandidates()
        {
            return _CandidateAppservice.GetAllCandidates();
        }
        //[AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CandidateDto> GetCandidate(int id)
        {
            var candidates = _CandidateAppservice.GetCandidate(id);

            if (candidates == null)
            {
                return NotFound();
            }

            return candidates;
        }
        // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutCandidate(int id, CandidateDto CandidateDto)
        {
            try
            {
                _CandidateAppservice.UpdateCandidate(CandidateDto, id);

                return Ok(CandidateDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<CandidateDto> PostCandidate(CandidateDto CandidateDto)
        {
            _CandidateAppservice.CreateCandidate(CandidateDto);
            return CreatedAtAction("GetCandidates", CandidateDto);

        }
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCandidate(int id)
        {
            _CandidateAppservice.DeleteCandidate(id);
            return NoContent();
        }

        private bool CandidateExists(int id)
        {
            return _CandidateAppservice.CheckCandidateExists(id);
        }


    }
}
