using JobHubWebAPI.ApplicationLayer.EFCoreService.LoadingWith;
using JobHubWebAPI.DataLayer.DataTransferObjects;
using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;
using Microsoft.AspNetCore.Mvc;
using static JobHubWebAPI.ApplicationLayer.EFCoreService.SortingJobs;

namespace JobHubWebAPI.Controllers
{
    [ApiController]
    [Route("JobHub/[action]")]
    public class MainController : ControllerBase
    {
        private readonly IJobService jobService;

        public MainController(IJobService jobService)
        {
            this.jobService = jobService;
        }
        [HttpGet]
        [Route("vacancies/{searchJob?}")]
        public ActionResult<JobDTO> LoadJob(string searchJob)
        {
            if (!string.IsNullOrEmpty(searchJob))
            {
                return Ok(jobService.GetSpecificJob(searchJob));
            }
            return Ok(jobService.GetAllMappedJob()); 
        }
        [HttpGet]
        [Route("profession/{int:id}")]
        public ActionResult<JobDTOItem> GetSpecificJobWithId(int id)
        {
            return Ok(jobService.GetCurrentJob(id));
        }
    }
}
