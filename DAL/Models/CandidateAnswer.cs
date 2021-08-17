using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CandidateAnswer
    {
        public int ID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public string QuestionBodyText { get; set; }
        [Required]
        public string AnswerBodyText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public Candidate Candidate { get; set; }

        [ForeignKey("Candidate")]
        public int CandidateID { get; set; }

    }
}
