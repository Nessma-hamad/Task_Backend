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
    
    public class CandidateRepository : BaseRepository<Candidate>
    {
        private DbContext EC_DbContext;
        public CandidateRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Candidate> GetAllCandidates()
        {
            return GetAll().ToList();
        }

        public bool InsertCandidate(Candidate Candidate)
        {
            return Insert(Candidate);
        }
        public void UpdateCandidate(Candidate Candidate)
        {
            Update(Candidate);
        }
        public void DeleteCandidate(int id)
        {
            Delete(id);
        }
        public bool CheckCandidateExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
        public Candidate GetCandidateById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }

    }
}
