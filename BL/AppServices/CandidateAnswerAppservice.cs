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
   
    public class CandidateAnswerAppservice : BaseAppService
    {
        public CandidateAnswerAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<CandidateAnswerDto> GetAllCandidateAnswers()
        {
            return mapper.Map<List<CandidateAnswerDto>>(TheUnitOfWork.CandidateAnswer.GetAllCandidateAnswers());
        }
        public CandidateAnswerDto GetCandidateAnswer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<CandidateAnswerDto>(TheUnitOfWork.CandidateAnswer.GetCandidateAnswerById(id));
        }
        public bool CreateCandidateAnswer(CandidateAnswerDto CandidateAnswerDto)
        {
            if (CandidateAnswerDto == null)

                throw new ArgumentNullException();



            bool result = false;
            var candidateAnswer = mapper.Map<CandidateAnswer>(CandidateAnswerDto);
            if (TheUnitOfWork.CandidateAnswer.InsertCandidateAnswer(candidateAnswer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteCandidateAnswer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.CandidateAnswer.DeleteCandidateAnswer(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckCandidateAnswerExists(int CandidateAnswerId)
        {
            var result = TheUnitOfWork.CandidateAnswer.CheckCandidateAnswerExists(CandidateAnswerId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public bool UpdateCandidateAnswer(CandidateAnswerDto CandidateAnswerDto, int id)
        {
            var CandidateAnswer = TheUnitOfWork.CandidateAnswer.GetCandidateAnswerById(id);
            CandidateAnswer.QuestionBodyText = CandidateAnswerDto.QuestionBodyText;
           



            TheUnitOfWork.CandidateAnswer.UpdateCandidateAnswer(CandidateAnswer);
            TheUnitOfWork.Commit();

            return true;
        }


    }
}
