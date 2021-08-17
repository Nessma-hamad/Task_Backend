using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string BodyText { get; set; }

        [ForeignKey("JobPosition")]
        public int JobPositionID { get; set; }

        public JobPosition JobPosition { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
