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

    public class AnswerRepository : BaseRepository<Answer>
    {
        private JrTaskDbContext EC_DbContext;
        public AnswerRepository(JrTaskDbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Answer> GetAllAnswers()
        {
            return GetAll().ToList();
        }
        public List<Answer> GetAllQuestionAnswes(int QuestionID)
        {
            return EC_DbContext.Answers.Where<Answer>(a => a.QuestionID == QuestionID).ToList();
        }

        public bool InsertAnswer(Answer Answer)
        {
            return Insert(Answer);
        }
        public void UpdateAnswer(Answer Answer)
        {
            Update(Answer);
        }
        public void DeleteAnswer(int id)
        {
            Delete(id);
        }
        public bool CheckAnswerExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
        public Answer GetAnswerById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }

    }
}
