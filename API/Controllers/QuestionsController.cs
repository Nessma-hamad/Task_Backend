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
  
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionAppservice _QuestionAppservice;

        public QuestionsController(QuestionAppservice QuestionAppservice)
        {
            _QuestionAppservice = QuestionAppservice;
        }
        [HttpGet]
        
        public ActionResult<IEnumerable<QuestionDto>> GetQuestions()
        {
            return _QuestionAppservice.GetAllQuestions();
        }
        [HttpGet("/JobPositionQuestions")]
       
        public ActionResult<IEnumerable<QuestionDto>> GetJobPositionQuestions(int JobPostionID)
        {
            return _QuestionAppservice.GetJobPositionQuestions(JobPostionID);
        }
        [HttpGet("/AllJobPositionQuestions")]
       
        public ActionResult<IEnumerable<QuestionDto>> GetAllJobPositionQuestions(int JobPostionID)
        {
            return _QuestionAppservice.GetAllJobPositionQuestions(JobPostionID);
        }
       
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
       
        [HttpPost]
        public ActionResult<QuestionDto> PostQuestion(QuestionDto QuestionDto)
        {
           var question= _QuestionAppservice.CreateQuestion(QuestionDto);
            return CreatedAtAction("GetQuestions", question);

        }
         
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
