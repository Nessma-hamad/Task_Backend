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
        //[AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<QuestionDto> GetQuestion(int id)
        {
            var brands = _QuestionAppservice.GetQuestion(id);

            if (brands == null)
            {
                return NotFound();
            }

            return brands;
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
            _QuestionAppservice.CreateQuestion(QuestionDto);
            return CreatedAtAction("GetQuestions", QuestionDto);

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
