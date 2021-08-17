using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DtoModels
{
    public class CandidateAnswerDto
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

        
        public int CandidateID { get; set; }
    }
}
