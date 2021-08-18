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
  

    public class AnswerAppservice : BaseAppService
    {
        public AnswerAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<AnswerDto> GetAllAnswers()
        {
            return mapper.Map<List<AnswerDto>>(TheUnitOfWork.Answer.GetAllAnswers());
        }
        public List<AnswerDto> GetQuestionAnswes(int QuestionID)
        {
            return mapper.Map<List<AnswerDto>>(TheUnitOfWork.Answer.GetAllQuestionAnswes(QuestionID));
        }
        public AnswerDto GetAnswer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<AnswerDto>(TheUnitOfWork.Answer.GetAnswerById(id));
        }
        public bool CreateAnswer(AnswerDto AnswerDto)
        {
            if (AnswerDto == null)

                throw new ArgumentNullException();



            bool result = false;
            var answer = mapper.Map<Answer>(AnswerDto);
            if (TheUnitOfWork.Answer.InsertAnswer(answer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteAnswer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Answer.DeleteAnswer(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckAnswerExists(int AnswerId)
        {
            var result = TheUnitOfWork.Answer.CheckAnswerExists(AnswerId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public bool UpdateAnswer(AnswerDto AnswerDto, int id)
        {
            var Answer = TheUnitOfWork.Answer.GetAnswerById(id);
            Answer.BodyText = AnswerDto.BodyText;
            Answer.IsCorrect = AnswerDto.IsCorrect;



            TheUnitOfWork.Answer.UpdateAnswer(Answer);
            TheUnitOfWork.Commit();

            return true;
        }


    }
}
