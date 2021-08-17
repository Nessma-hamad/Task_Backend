using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("JobPositionID")]
        public JobPosition JobPosition { get; set; }
        public int JobPositionID { get; set; }

        public ICollection<CandidateAnswer> CandidateAnswers { get; set; }
    }
}
