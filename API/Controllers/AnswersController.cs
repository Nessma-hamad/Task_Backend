﻿using BL.AppServices;
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
   
    public class AnswersController : ControllerBase
    {
        private readonly AnswerAppservice _AnswerAppservice;

        public AnswersController(AnswerAppservice AnswerAppservice)
        {
            _AnswerAppservice = AnswerAppservice;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AnswerDto>> GetAnswers()
        {
            return _AnswerAppservice.GetAllAnswers();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<AnswerDto> GetAnswer(int id)
        {
            var answers = _AnswerAppservice.GetAnswer(id);

            if (answers == null)
            {
                return NotFound();
            }

            return answers;
        }
        [AllowAnonymous]
        [HttpGet("/QuestionAnswes")]
        public ActionResult<IEnumerable<AnswerDto>> QuestionAnswes(int QuestionID)
        {
            var answers = _AnswerAppservice.GetQuestionAnswes(QuestionID);

            if (answers == null)
            {
                return NotFound();
            }

            return answers;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult PutAnswer(int id, AnswerDto AnswerDto)
        {
            try
            {
                _AnswerAppservice.UpdateAnswer(AnswerDto, id);

                return Ok(AnswerDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<AnswerDto> PostAnswer(AnswerDto AnswerDto)
        {
            _AnswerAppservice.CreateAnswer(AnswerDto);
            return CreatedAtAction("GetAnswers", AnswerDto);

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAnswer(int id)
        {
            _AnswerAppservice.DeleteAnswer(id);
            return NoContent();
        }

        private bool AnswerExists(int id)
        {
            return _AnswerAppservice.CheckAnswerExists(id);
        }


    }
}
