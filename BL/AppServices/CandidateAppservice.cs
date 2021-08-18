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
    public class CandidateAppservice : BaseAppService
    {
        public CandidateAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<CandidateDto> GetAllCandidates()
        {
            return mapper.Map<List<CandidateDto>>(TheUnitOfWork.Candidate.GetAllCandidates());
        }
        public CandidateDto GetCandidate(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<CandidateDto>(TheUnitOfWork.Candidate.GetCandidateById(id));
        }
        public bool CreateCandidate(CandidateDto CandidateDto)
        {
            if (CandidateDto == null)

                throw new ArgumentNullException();



            bool result = false;
            var candidate = mapper.Map<Candidate>(CandidateDto);
            if (TheUnitOfWork.Candidate.InsertCandidate(candidate))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteCandidate(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Candidate.DeleteCandidate(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckCandidateExists(int CandidateId)
        {
            var result = TheUnitOfWork.Candidate.CheckCandidateExists(CandidateId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public bool UpdateCandidate(CandidateDto CandidateDto, int id)
        {
            var Candidate = TheUnitOfWork.Candidate.GetCandidateById(id);
            Candidate.Name = CandidateDto.Name;
            Candidate.JobPositionID = CandidateDto.JobPositionID;




            TheUnitOfWork.Candidate.UpdateCandidate(Candidate);
            TheUnitOfWork.Commit();

            return true;
        }


    }
}
