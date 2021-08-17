using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DtoModels
{
    public class QuestionDto
    {
        public int ID { get; set; }
        public string BodyText { get; set; }

        public int JobPositionID { get; set; }

       
        public ICollection<Answer> Answers { get; set; }
    }
}
