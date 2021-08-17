using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class JobPosition
    { 
       
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Question> Questions{ get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}
