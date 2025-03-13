using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Entities;

namespace JobHubWebAPI.DataLayer.Repositores.RepositoryInterfaces
{
    public interface IJobsRepo
    {
        public IQueryable<Job> GetAllJobs(); // parametr used for searching which I will use Contains Method . Containt method is one of three method (EndsWith,StartsWith,Contains) that Ef core run in server side .
        public IQueryable<Job> GetSearchedJobs(string searchJob);
    }
}
