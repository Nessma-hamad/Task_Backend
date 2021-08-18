using BL.Interfaces;
using BL.Repostories;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        private JrTaskDbContext EC_DbContext { get; set; }
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UnitOfWork(JrTaskDbContext EC_DbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.EC_DbContext = EC_DbContext;
        }
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }
        public void Dispose()
        {
            EC_DbContext.Dispose();
        }


        public AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext, _userManager, _roleManager);
                return account;
            }
        }

        public AnswerRepository answer;
        public AnswerRepository Answer
        {
            get
            {
                if (answer == null)
                    answer = new AnswerRepository(EC_DbContext);
                return answer;
            }
        }

        public CandidateAnswerRepository candidateAnswer;
        public CandidateAnswerRepository CandidateAnswer
        {
            get
            {
                if (candidateAnswer == null)
                    candidateAnswer = new CandidateAnswerRepository(EC_DbContext);
                return candidateAnswer;
            }
        }

        public CandidateRepository candidate;
        public CandidateRepository Candidate
        {
            get
            {
                if (candidate == null)
                    candidate = new CandidateRepository(EC_DbContext);
                return candidate;
            }
        }

        public JobPositionRepository jobPosition;
        public JobPositionRepository JobPosition
        {
            get
            {
                if (jobPosition == null)
                    jobPosition = new JobPositionRepository(EC_DbContext);
                return jobPosition;
            }
        }

        public QuestionRepository guestion;
        public QuestionRepository Question
        {
            get
            {
                if (guestion == null)
                    guestion = new QuestionRepository(EC_DbContext);
                return guestion;
            }
        }

    }
}
