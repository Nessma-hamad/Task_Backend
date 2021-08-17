using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DtoModels
{
    public class CandidateDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public int JobPositionID { get; set; }

        public ICollection<CandidateAnswer> CandidateAnswers { get; set; }
    }
}
