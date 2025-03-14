using JobHubWebAPI.DataLayer.DataBaseConnection;
using JobHubWebAPI.DATALAYER.Repositores.ServicesR;
using Microsoft.EntityFrameworkCore;

namespace JobHubWebAPI.DATALAYER.Repositores.ImplementationR
{
    public class AccountRepo : IAccountRepo
    {
        private readonly JobHubDataBaseContext context;

        public AccountRepo(JobHubDataBaseContext context)
        {
            this.context = context;
        }
        public IQueryable<AppUser> GetUserAccount()
        {
            return context.Users.Include(a => a.CompanyProfile).ThenInclude(a => a.JobsList);
            // second level relation from AppUser which is in Users Table to Company then Job
        }
    }
}
