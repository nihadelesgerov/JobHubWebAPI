using JobHubWebAPI.DataLayer.DataTransferObjects.JobDTO;

namespace JobHubWebAPI.ApplicationLayer.EFCoreService
{
    public static  class SortingJobs
    {
        public static IQueryable<JobDTO> SortJobDTO(this IQueryable<JobDTO> jobs,SortingOptions options)
        {
            switch (options)
            {
                case SortingOptions.SortSalaryFromMax:
                    return jobs.OrderByDescending(x => x.Salary);
                case SortingOptions.SortSalaryFromMin:
                    return jobs.OrderBy(x=> x.Salary);
               default:
                    return jobs.OrderByDescending(x => x.JobPostedAt);
            }
        }
        public enum SortingOptions
        {
            SortSalaryFromMax,
            SortSalaryFromMin,
        }
    }
}
