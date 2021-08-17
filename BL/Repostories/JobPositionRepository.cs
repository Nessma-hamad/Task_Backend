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

    public class JobPositionRepository : BaseRepository<JobPosition>
    {
        private DbContext EC_DbContext;
        public JobPositionRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<JobPosition> GetAllJobPositions()
        {
            return GetAll().ToList();
        }

        public bool InsertJobPosition(JobPosition JobPosition)
        {
            return Insert(JobPosition);
        }
        public void UpdateJobPosition(JobPosition JobPosition)
        {
            Update(JobPosition);
        }
        public void DeleteJobPosition(int id)
        {
            Delete(id);
        }
        public bool CheckJobPositionExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
        public JobPosition GetJobPositionById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }

    }
}
