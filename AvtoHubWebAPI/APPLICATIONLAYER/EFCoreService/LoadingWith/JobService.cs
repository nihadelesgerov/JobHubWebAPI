using JobHubWebAPI.DataLayer.DataTransferObjects;
using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Repositores.RepositoryInterfaces;

namespace JobHubWebAPI.ApplicationLayer.EFCoreService.LoadingWith
{
    public class JobService : IJobService
    {
        private readonly IJobsRepo jobsRepo;

        public JobService(IJobsRepo jobsRepo)
        {
            this.jobsRepo = jobsRepo;
        }
        public IQueryable<JobDTO> GetAllMappedJob()
        {
            return jobsRepo.GetAllJobs().MapJobDTO();
        }
        public IQueryable<JobDTO> GetSpecificJob(string searchJob)
        {
            return jobsRepo.GetSearchedJobs(searchJob).MapJobDTO();
        }
        public JobDTOItem GetCurrentJob(int id)
        {
            return jobsRepo.GetAllJobs().MapCurrentJob(id) ;
        }
    }
}
