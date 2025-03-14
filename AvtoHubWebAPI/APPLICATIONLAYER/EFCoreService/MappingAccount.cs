using JobHubWebAPI.DataLayer.DataBaseConnection;
using JobHubWebAPI.DATALAYER.DataTransferObjects;

namespace JobHubWebAPI.APPLICATIONLAYER.EFCoreService
{
    public static  class MappingAccount
    {
        public static AccountDTO MapAccount(this IQueryable<AppUser> users,string id)
        {
            return users.Select(x => new AccountDTO
            {
                Email = x.Email,
                CompanyEmailAdress = x.CompanyProfile.CompanyEmailAdress,
                JobsOfCompany =x.CompanyProfile.JobsList,
            }).First(a=>a.Id==id);
        }
        public static AccountDTO MapAccountForEdit(this IQueryable<AppUser> users, string id)
        {
            return users.Select(x => new AccountDTO
            {
                Email = x.Email,
                CompanyName = x.CompanyProfile.CompanyName,
                CompanyAdress = x.CompanyProfile.CompanyAdress,
                CompanyPhoneAdress = x.CompanyProfile.CompanyPhoneAdress,
                CompanyEmailAdress = x.CompanyProfile.CompanyEmailAdress,
                CompanyDescription = x.CompanyProfile.CompanyDescription,
            }).First(a => a.Id == id);
        }
    }
}
