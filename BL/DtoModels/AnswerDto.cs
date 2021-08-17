using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DtoModels
{
   public  class AnswerDto
    {
        public int ID { get; set; }
        [Required]
        public string BodyText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
    }
}
