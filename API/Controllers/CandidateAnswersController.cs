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
  
    public class CandidateAnswersController : ControllerBase
    {
        private readonly CandidateAnswerAppservice _CandidateAnswerAppservice;

        public CandidateAnswersController(CandidateAnswerAppservice CandidateAnswerAppservice)
        {
            _CandidateAnswerAppservice = CandidateAnswerAppservice;
        }
        [HttpGet]
       
        public ActionResult<IEnumerable<CandidateAnswerDto>> GetCandidateAnswers()
        {
            return _CandidateAnswerAppservice.GetAllCandidateAnswers();
        }
        [HttpGet("/GetCandidateAnswersByID")]
       
        public ActionResult<IEnumerable<CandidateAnswerDto>> GetCandidateAnswersByID(int candidateID)
        {
            return _CandidateAnswerAppservice.GetCandidateAnswersByID(candidateID);
        }
       
        [HttpGet("{id}")]
        public ActionResult<CandidateAnswerDto> GetCandidateAnswer(int id)
        {
            var candidateAnswers = _CandidateAnswerAppservice.GetCandidateAnswer(id);

            if (candidateAnswers == null)
            {
                return NotFound();
            }

            return candidateAnswers;
        }
       
        [HttpPut("{id}")]
        public IActionResult PutCandidateAnswer(int id, CandidateAnswerDto CandidateAnswerDto)
        {
            try
            {
                _CandidateAnswerAppservice.UpdateCandidateAnswer(CandidateAnswerDto, id);

                return Ok(CandidateAnswerDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost]
        public ActionResult<CandidateAnswerDto> PostCandidateAnswer(CandidateAnswerDto CandidateAnswerDto)
        {
            _CandidateAnswerAppservice.CreateCandidateAnswer(CandidateAnswerDto);
            return CreatedAtAction("GetCandidateAnswers", CandidateAnswerDto);

        }
        
       
        [HttpDelete("{id}")]
        public IActionResult DeleteCandidateAnswer(int id)
        {
            _CandidateAnswerAppservice.DeleteCandidateAnswer(id);
            return NoContent();
        }

        private bool CandidateAnswerExists(int id)
        {
            return _CandidateAnswerAppservice.CheckCandidateAnswerExists(id);
        }


    }
}
