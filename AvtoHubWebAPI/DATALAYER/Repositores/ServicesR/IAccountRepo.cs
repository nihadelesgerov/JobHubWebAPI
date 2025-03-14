using JobHubWebAPI.DataLayer.DataBaseConnection;

namespace JobHubWebAPI.DATALAYER.Repositores.ServicesR
{
    public interface IAccountRepo
    {
        public IQueryable<AppUser> GetUserAccount();
    }
}
