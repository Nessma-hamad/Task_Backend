using AutoMapper;
using BL.DtoModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configration
{
    public class AutoMapperProfile
    {
        public static IMapper mapper { get; set; }

        static AutoMapperProfile()
        {
            var config = new MapperConfiguration(
                cog =>
                {
                   
                    cog.CreateMap<User, RegisterationDto>().ReverseMap();
                    cog.CreateMap<User, LoginDto>().ReverseMap();
                    cog.CreateMap<Answer, AnswerDto>().ReverseMap();
                    cog.CreateMap<Candidate, CandidateDto>().ReverseMap();
                    cog.CreateMap<CandidateAnswer, CandidateAnswerDto>().ReverseMap();
                    cog.CreateMap<JobPosition, JobPositionDto>().ReverseMap();
                    cog.CreateMap<Question, QuestionDto>().ReverseMap();

                });

            mapper = config.CreateMapper();
        }

    }
}
