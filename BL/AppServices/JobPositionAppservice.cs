using BL.Bases;
using BL.DtoModels;
using BL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
   
    public class JobPositionAppservice : BaseAppService
    {
        public JobPositionAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<JobPositionDto> GetAllJobPositions()
        {
            return mapper.Map<List<JobPositionDto>>(TheUnitOfWork.JobPosition.GetAllJobPositions());
        }
        public JobPositionDto GetJobPosition(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return mapper.Map<JobPositionDto>(TheUnitOfWork.JobPosition.GetJobPositionById(id));
        }
        public bool CreateJobPosition(JobPositionDto JobPositionDto)
        {
            if (JobPositionDto == null)

                throw new ArgumentNullException();



            bool result = false;
            var jobPosition = mapper.Map<JobPosition>(JobPositionDto);
            if (TheUnitOfWork.JobPosition.InsertJobPosition(jobPosition))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteJobPosition(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.JobPosition.DeleteJobPosition(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckJobPositionExists(int JobPositionId)
        {
            var result = TheUnitOfWork.JobPosition.CheckJobPositionExists(JobPositionId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public bool UpdateJobPosition(JobPositionDto JobPositionDto, int id)
        {
            var jobPosition = TheUnitOfWork.JobPosition.GetJobPositionById(id);
            jobPosition.Title = JobPositionDto.Title;
           
            
           
            TheUnitOfWork.JobPosition.UpdateJobPosition(jobPosition);
            TheUnitOfWork.Commit();

            return true;
        }


    }
}
