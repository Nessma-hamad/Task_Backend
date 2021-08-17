using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repostories
{

    public class CandidateAnswerRepository : BaseRepository<CandidateAnswer>
    {
        private DbContext EC_DbContext;
        public CandidateAnswerRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<CandidateAnswer> GetAllCandidateAnswers()
        {
            return GetAll().ToList();
        }

        public bool InsertCandidateAnswer(CandidateAnswer CandidateAnswer)
        {
            return Insert(CandidateAnswer);
        }
        public void UpdateCandidateAnswer(CandidateAnswer CandidateAnswer)
        {
            Update(CandidateAnswer);
        }
        public void DeleteCandidateAnswer(int id)
        {
            Delete(id);
        }
        public bool CheckCandidateAnswerExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
        public CandidateAnswer GetCandidateAnswerById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }

    }
}
