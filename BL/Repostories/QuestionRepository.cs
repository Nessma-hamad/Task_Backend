using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repostories
{
   
    public class QuestionRepository : BaseRepository<Question>
    {
        private JrTaskDbContext EC_DbContext;
        public QuestionRepository(JrTaskDbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Question> GetAllQuestions()
        {
            return GetAll().ToList();
        }
        public List<Question> GetJobPositionQuestions(int JobPostionID)
        {
            return EC_DbContext.Questions.Where<Question>(q => q.JobPositionID == JobPostionID).Take<Question>(5).ToList();
        }

        public List<Question> GetAllJobPositionQuestions(int JobPostionID)
        {
            return EC_DbContext.Questions.Where<Question>(q => q.JobPositionID == JobPostionID).ToList();
        }
        public bool InsertQuestion(Question Question)
        {
            return Insert(Question);
        }
        public void UpdateQuestion(Question Question)
        {
            Update(Question);
        }
        public void DeleteQuestion(int id)
        {
            Delete(id);
        }
        public bool CheckQuestionExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
        public Question GetQuestionById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }

    }
}
