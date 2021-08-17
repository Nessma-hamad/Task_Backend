using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Answer
    {
        public int ID { get; set; }
        [Required]
        public string  BodyText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }
    }
}
