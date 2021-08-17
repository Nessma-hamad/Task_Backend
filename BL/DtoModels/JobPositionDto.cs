using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DtoModels
{
    public class JobPositionDto
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}
