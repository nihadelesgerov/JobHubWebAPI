using JobHubWebAPI.ApplicationLayer.EFCoreService;
using JobHubWebAPI.DataLayer.DataBaseConnection;
using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Entities;
using JobHubWebAPI.DataLayer.Repositores.RepositoryInterfaces;

namespace JobHubWebAPI.DataLayer.Repositores.ImplementationR
{
    public class JobsRepo : IJobsRepo
    {
        private readonly JobHubDataBaseContext context;

        public JobsRepo(JobHubDataBaseContext context)
        {
            this.context = context;
        }
        public IQueryable<Job> GetAllJobs()
        {
            return context.JobTable;
        }
        public IQueryable<Job> GetSearchedJobs(string seachJob)
        {
            return context.JobTable.Where(a => a.Title.Contains(seachJob));
        }
    }
}
