using JobHubWebAPI.DataLayer.DataTransferObjects;
using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Entities;

namespace JobHubWebAPI.ApplicationLayer.EFCoreService
{
    public static  class MappingJobs
    {
        public static IQueryable<JobDTO> MapJobDTO(this IQueryable<Job> jobs)
        {
            return jobs.Select(x => new JobDTO
            {
                JobId = x.Id,
                Title  = x.Title,
                JobPostedAt = x.PostedAt,
                Location = x.Location,
                Salary = x.Salary,
                CompanyName = x.Company.CompanyName
            });
        }
        public static JobDTOItem MapCurrentJob(this IQueryable<Job> jobs,int id)
        {
            return jobs.Select(x => new JobDTOItem
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Location = x.Location,
                Salary = x.Salary,
                Skills = x.Skills,
                PostedAt = x.PostedAt,
                ApplicationDeadline = x.ApplicationDeadline,
                CompanyName = x.Company.CompanyName,
                CompanyEmail = x.Company.CompanyEmailAdress
            }).First(a=>a.Id==id);
        }
    }
}
