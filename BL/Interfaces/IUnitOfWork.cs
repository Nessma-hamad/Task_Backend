using BL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();



        AccountRepository Account { get; }
        AnswerRepository Answer { get; }
        CandidateAnswerRepository CandidateAnswer { get; }
        CandidateRepository Candidate { get; }
        JobPositionRepository JobPosition { get; }

        QuestionRepository Question { get; }
    }
}
