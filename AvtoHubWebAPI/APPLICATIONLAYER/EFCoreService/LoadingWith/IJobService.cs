using JobHubWebAPI.DataLayer.DataTransferObjects;
using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using JobHubWebAPI.DataLayer.Repositores.RepositoryInterfaces;

namespace JobHubWebAPI.ApplicationLayer.EFCoreService.LoadingWith
{
    public interface IJobService
    {
        public IQueryable<JobDTO> GetAllMappedJob();
        public IQueryable<JobDTO> GetSpecificJob(string searchJob);
        public JobDTOItem GetCurrentJob(int id);
    }
}
