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
  
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionAppservice _QuestionAppservice;

        public QuestionsController(QuestionAppservice QuestionAppservice)
        {
            _QuestionAppservice = QuestionAppservice;
        }
        [HttpGet]
        // [AllowAnonymous]
        public ActionResult<IEnumerable<QuestionDto>> GetQuestions()
        {
            return _QuestionAppservice.GetAllQuestions();
        }
        [HttpGet("/JobPositionQuestions")]
        // [AllowAnonymous]
        public ActionResult<IEnumerable<QuestionDto>> GetJobPositionQuestions(int JobPostionID)
        {
            return _QuestionAppservice.GetJobPositionQuestions(JobPostionID);
        }
        [HttpGet("/AllJobPositionQuestions")]
        // [AllowAnonymous]
        public ActionResult<IEnumerable<QuestionDto>> GetAllJobPositionQuestions(int JobPostionID)
        {
            return _QuestionAppservice.GetAllJobPositionQuestions(JobPostionID);
        }
        //[AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<QuestionDto> GetQuestion(int id)
        {
            var questions = _QuestionAppservice.GetQuestion(id);

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }
        // [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutQuestion(int id, QuestionDto QuestionDto)
        {
            try
            {
                _QuestionAppservice.UpdateQuestion(QuestionDto, id);

                return Ok(QuestionDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<QuestionDto> PostQuestion(QuestionDto QuestionDto)
        {
           var question= _QuestionAppservice.CreateQuestion(QuestionDto);
            return CreatedAtAction("GetQuestions", question);

        }
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            _QuestionAppservice.DeleteQuestion(id);
            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _QuestionAppservice.CheckQuestionExists(id);
        }


    }
}
