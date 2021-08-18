using BL.Bases;
using BL.DtoModels;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
  
    public class QuestionAppservice : BaseAppService
    {
        public QuestionAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<QuestionDto> GetAllQuestions()
        {
            return mapper.Map<List<QuestionDto>>(TheUnitOfWork.Question.GetAllQuestions());
        }
        public List<QuestionDto> GetJobPositionQuestions(int JobPostionID)
        {
            return mapper.Map<List<QuestionDto>>(TheUnitOfWork.Question.GetJobPositionQuestions(JobPostionID));
        }
        public QuestionDto GetQuestion(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<QuestionDto>(TheUnitOfWork.Question.GetQuestionById(id));
        }
        public bool CreateQuestion(QuestionDto QuestionDto)
        {
            if (QuestionDto == null)

                throw new ArgumentNullException();



            bool result = false;
            var Question = mapper.Map<Question>(QuestionDto);
            if (TheUnitOfWork.Question.InsertQuestion(Question))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteQuestion(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Question.DeleteQuestion(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckQuestionExists(int QuestionId)
        {
            var result = TheUnitOfWork.Question.CheckQuestionExists(QuestionId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public bool UpdateQuestion(QuestionDto QuestionDto, int id)
        {
            var Question = TheUnitOfWork.Question.GetQuestionById(id);
            Question.BodyText = QuestionDto.BodyText;



            TheUnitOfWork.Question.UpdateQuestion(Question);
            TheUnitOfWork.Commit();

            return true;
        }


    }
}
