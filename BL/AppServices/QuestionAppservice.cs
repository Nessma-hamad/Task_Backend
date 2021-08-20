using BL.Bases;
using BL.DtoModels;
using BL.Interfaces;
using DAL;
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
        JrTaskDbContext _DbContext;
        public QuestionAppservice(JrTaskDbContext DbContext,IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {
            _DbContext = DbContext;

        }
        public List<QuestionDto> GetAllQuestions()
        {
            return mapper.Map<List<QuestionDto>>(TheUnitOfWork.Question.GetAllQuestions());
        }
        public List<QuestionDto> GetJobPositionQuestions(int JobPostionID)
        {
            return mapper.Map<List<QuestionDto>>(TheUnitOfWork.Question.GetJobPositionQuestions(JobPostionID));
        }
        public List<QuestionDto> GetAllJobPositionQuestions(int JobPostionID)
        {
            return mapper.Map<List<QuestionDto>>(TheUnitOfWork.Question.GetAllJobPositionQuestions(JobPostionID));
        }
        public QuestionDto GetQuestion(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<QuestionDto>(TheUnitOfWork.Question.GetQuestionById(id));
        }
        public QuestionDto CreateQuestion(QuestionDto questionDto)
        {
            if (questionDto == null)

                throw new ArgumentNullException();


            var lastQuestion = new QuestionDto() ;
            bool result = false;
            var Question = mapper.Map<Question>(questionDto);
            if (TheUnitOfWork.Question.InsertQuestion(Question))
            {
                result = TheUnitOfWork.Commit() > new int();
                 lastQuestion= mapper.Map <QuestionDto> (_DbContext.Questions.OrderByDescending(q=>q.ID).FirstOrDefault());

            }
            return lastQuestion;
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
