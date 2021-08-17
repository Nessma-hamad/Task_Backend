using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JrTaskDbContext : IdentityDbContext<User>
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Data Source=.;Initial Catalog=JrTask;Integrated Security=True"
            , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public JrTaskDbContext() : base()
        {

        }
        public JrTaskDbContext(DbContextOptions<JrTaskDbContext> options ) :base(options)
        {

        }
        

        

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateAnswer> CandidateAnswers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
       
        public class ApplicationUserStore : UserStore<User>
        {
            public ApplicationUserStore() : base(new JrTaskDbContext())
            {

            }
            public ApplicationUserStore(DbContext db) : base(db)
            {

            }
        }
    }
}
